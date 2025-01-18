using AnimeVoices.Models;
using AnimeVoices.Stores;
using AnimeVoices.Utilities.Events;
using AnimeVoices.ViewModels.Content.InfoPanels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AnimeInfoViewModel : BaseViewModel, IRecipient<SearchTextChanged>
    {
        #region Parameters
        // Full and filtered data
        [ObservableProperty] 
        private ObservableCollection<Anime> _animeList;
        [ObservableProperty] 
        private ObservableCollection<Character> _filteredCharacterList;
        [ObservableProperty] 
        private ObservableCollection<Result> _resultList;

        // Info panels ViewModels
        [ObservableProperty] ObservableObject _infoPanelViewModel;
        private readonly int _panelUiDelay = 200;

        // Currently selected items
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(HideExpandCharactersListCommand))]
        [NotifyCanExecuteChangedFor(nameof(ShowAnimeInfoCommand))]
        private Anime _selectedAnime;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(HideExpandResultListCommand))]
        [NotifyCanExecuteChangedFor(nameof(ShowCharacterInfoCommand))]
        private Character _selectedCharacter;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowResultInfoCommand))]
        private Result _selectedResult;
        [ObservableProperty] 
        private Seiyuu _foundSeiyuu;

        // UI control properties
        [ObservableProperty] private bool _animeListExpanded;
        [ObservableProperty] private bool _characterListExpanded;
        [ObservableProperty] private bool _resultListExpanded;

        // User login state
        [ObservableProperty] private bool _isUserLoggedIn;
        [ObservableProperty] private User _loggedUser;

        // Constructor parameters
        private readonly AnimeStore _animeStore;
        private readonly CharacterStore _characterStore;
        private readonly SeiyuuStore _seiyuuStore;
        private readonly AnimeInfoPanelViewModel _animeInfoPanelViewModel;
        private readonly CharacterInfoPanelViewModel _characterInfoPanelViewModel;
        private readonly ResultInfoPanelViewModel _resultInfoPanelViewModel;
        #endregion

        #region Constructors
        public AnimeInfoViewModel(IMessenger messenger, AnimeStore animeStore, CharacterStore characterStore, SeiyuuStore seiyuuStore, AnimeInfoPanelViewModel animeInfoPanelViewModel, CharacterInfoPanelViewModel characterInfoPanelViewModel, ResultInfoPanelViewModel resultInfoPanelViewModel) : base(messenger)
        {
            _animeStore = animeStore;
            _characterStore = characterStore;
            _seiyuuStore = seiyuuStore;
            _animeInfoPanelViewModel = animeInfoPanelViewModel;
            _characterInfoPanelViewModel = characterInfoPanelViewModel;
            _resultInfoPanelViewModel = resultInfoPanelViewModel;

            _messenger.RegisterAll(this);

            LoggedUser = null;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = true;
            CharacterListExpanded = false;
            ResultListExpanded = false;

            AnimeList = _animeStore.AnimeCollection;
            FilteredCharacterList = new();
            ResultList = new();
        }
        #endregion

        #region Commands
        [RelayCommand(CanExecute = "CanAnimeListDropDown")]
        public void HideExpandAnimeList(string list)
        {
            CharacterListExpanded = false;
            ResultListExpanded = false;
            AnimeListExpanded = !AnimeListExpanded;

            if (!AnimeListExpanded && !CharacterListExpanded && !ResultListExpanded && ResultList.Count > 0)
            {
                ResultListExpanded = true;
            }
        }
        private bool CanAnimeListDropDown() => AnimeList.Count > 0;

        [RelayCommand(CanExecute = "CanCharacterListDropDown")]
        public void HideExpandCharactersList(string list)
        {
            AnimeListExpanded = false;
            ResultListExpanded = false;
            CharacterListExpanded = !CharacterListExpanded;
        }
        private bool CanCharacterListDropDown() => FilteredCharacterList.Count > 0;

        [RelayCommand(CanExecute = "CanResultListDropDown")]
        public void HideExpandResultList()
        {
            AnimeListExpanded = false;
            CharacterListExpanded = false;
            ResultListExpanded = !ResultListExpanded;

            if(!AnimeListExpanded && !CharacterListExpanded && !ResultListExpanded)
            {
                AnimeListExpanded = true;
            }
        }
        private bool CanResultListDropDown() => ResultList.Count > 0;

        [RelayCommand(CanExecute = "CanShowAnimeInfo")]
        public async void ShowAnimeInfo()
        {
            bool isPanelClosed = InfoPanelViewModel == null;
            bool isThisPanelsOpened = InfoPanelViewModel == _animeInfoPanelViewModel;
            InfoPanelViewModel = null;
            if (!isPanelClosed)
            {
                await Task.Delay(_panelUiDelay);
            }
            if (!isThisPanelsOpened)
            {
                InfoPanelViewModel = _animeInfoPanelViewModel;
            }
        }
        private bool CanShowAnimeInfo() => SelectedAnime != null;

        [RelayCommand(CanExecute = "CanShowCharacterInfo")]
        public async void ShowCharacterInfo()
        {
            bool isPanelClosed = InfoPanelViewModel == null;
            bool isThisPanelsOpened = InfoPanelViewModel == _characterInfoPanelViewModel;
            InfoPanelViewModel = null;
            if (!isPanelClosed)
            {
                await Task.Delay(_panelUiDelay);
            }
            if (!isThisPanelsOpened)
            {
                InfoPanelViewModel = _characterInfoPanelViewModel;
            }
        }
        private bool CanShowCharacterInfo() => SelectedCharacter != null;

        [RelayCommand(CanExecute = "CanShowResultInfo")]
        public async void ShowResultInfo()
        {
            bool isPanelClosed = InfoPanelViewModel == null;
            bool isThisPanelsOpened = InfoPanelViewModel == _resultInfoPanelViewModel;
            InfoPanelViewModel = null;
            if (!isPanelClosed)
            {
                await Task.Delay(_panelUiDelay);
            }
            if (!isThisPanelsOpened)
            {
                InfoPanelViewModel = _resultInfoPanelViewModel;
            }
        }
        private bool CanShowResultInfo() => SelectedResult != null;
        #endregion

        #region Partial Methods
        partial void OnSelectedAnimeChanged(Anime value)
        {
            _messenger.Send(new SelectedAnimeChanged(value));

            FilteredCharacterList.Clear();
            if (value == null)
            {
                return;
            }

            foreach (var character in _characterStore.CharacterCollection)
            {
                if (value.Characters.Contains(character.Id))
                {
                    FilteredCharacterList.Add(character);
                }
            }
        }

        partial void OnSelectedCharacterChanged(Character value)
        {
            ResultList.Clear();
            if (value == null)
            {
                _messenger.Send(new SelectedCharacterChanged(null, null));
                return;
            }

            FoundSeiyuu = _seiyuuStore.SeiyuuCollection.ToList().Find(s => value.Seiyuu == s.Id);
            _messenger.Send(new SelectedCharacterChanged(value, FoundSeiyuu));

            if (FoundSeiyuu != null) 
            {
                List<Character> sameCharacters = _characterStore.CharacterCollection.ToList().FindAll(c => FoundSeiyuu.Id == c.Seiyuu);

                foreach (Character character in sameCharacters)
                {
                    if (value.Id != character.Id)
                    {
                        List<Anime> characterAnime =  _animeStore.AnimeCollection.ToList().FindAll(a => a.Characters.Contains(character.Id));
                        string shortestTitle = null;

                        // Make sure that Anime Title on the list will be the same for Characters from same Animes no matter on what part user click
                        foreach (Anime anime in characterAnime)
                        {
                            if (shortestTitle == null || anime.Title.Length < shortestTitle.Length)
                            {
                                shortestTitle = anime.Title;
                            }
                        }

                        Result res = new Result(shortestTitle, character.Name, character.ImageUrl);
                        ResultList.Add(res);
                    }
                }
            }
        }

        partial void OnSelectedResultChanged(Result value)
        {
            _messenger.Send(new SelectedResultChanged(value, SelectedCharacter));
        }

        #endregion

        #region Messages
        public void Receive(SearchTextChanged message)
        {
            if (AnimeListExpanded)
            {
                if (string.IsNullOrEmpty(message.text))
                {
                    AnimeList = _animeStore.AnimeCollection;
                }
                else
                {
                    _animeStore.FilteredAnimeCollection.Clear();
                    foreach(Anime a in _animeStore.AnimeCollection)
                    {
                        if (a.Title.ToLower().Contains(message.text.ToLower()))
                        {
                            _animeStore.FilteredAnimeCollection.Add(a);
                        }
                    }
                    AnimeList = _animeStore.FilteredAnimeCollection;
                }
            }
            else if (CharacterListExpanded)
            {
                if (string.IsNullOrEmpty(message.text))
                {
                    FilteredCharacterList = _characterStore.CharacterCollection;
                }
                else
                {
                    _characterStore.ClearFiltered();
                    foreach (Character c in _characterStore.CharacterCollection)
                    {
                        if (c.Name.ToLower().Contains(message.text.ToLower()))
                        {
                            _characterStore.AddToFiltered(c);
                        }
                    }
                    FilteredCharacterList = _characterStore.FilteredCharacterCollection;
                }
            }
        }
        #endregion
    }
}
