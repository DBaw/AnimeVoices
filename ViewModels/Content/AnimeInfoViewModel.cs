using AnimeVoices.Models;
using AnimeVoices.Stores;
using AnimeVoices.Utilities.Events;
using AnimeVoices.Utilities.Helpers;
using AnimeVoices.ViewModels.Content.InfoPanels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AnimeInfoViewModel : BaseViewModel, IRecipient<AnimeCollectionChanged>, IRecipient<CharacterCollectionChanged>, IRecipient<SeiyuuCollectionChanged>
    {
        #region Parameters
        // Full and filtered data
        [ObservableProperty] 
        private ObservableCollection<Anime> _filteredAnimeList;
        [ObservableProperty] 
        private ObservableCollection<Character> _filteredCharacterList;
        [ObservableProperty] 
        private ObservableCollection<Result> _resultList;

        // Info panels ViewModels
        [ObservableProperty] ObservableObject _infoPanelViewModel;

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
        private readonly IMessenger _messenger;
        private readonly AnimeStore _animeStore;
        private readonly CharacterStore _characterStore;
        private readonly SeiyuuStore _seiyuuStore;
        #endregion

        #region Constructors
        public AnimeInfoViewModel(IMessenger messenger, AnimeStore animeStore, CharacterStore characterStore, SeiyuuStore seiyuuStore) : base(messenger)
        {
            _messenger = messenger;
            _animeStore = animeStore;
            _characterStore = characterStore;
            _seiyuuStore = seiyuuStore;

            LoggedUser = null;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = true;
            CharacterListExpanded = false;
            ResultListExpanded = false;

            FilteredAnimeList = new(_animeStore.AnimeCollection);
            FilteredCharacterList = new();
            ResultList = new ObservableCollection<Result>();
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
        private bool CanAnimeListDropDown() => FilteredAnimeList.Count > 0;

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
        public void ShowAnimeInfo()
        {
            bool isPanelsOpened = InfoPanelViewModel != null;
            InfoPanelViewModel = null;
            if(!isPanelsOpened) 
            {
                InfoPanelViewModel = new AnimeInfoPanelViewModel(SelectedAnime); 
            }
        }
        private bool CanShowAnimeInfo() => SelectedAnime != null;

        [RelayCommand(CanExecute = "CanShowCharacterInfo")]
        public void ShowCharacterInfo()
        {
            bool isPanelsOpened = InfoPanelViewModel != null;
            InfoPanelViewModel = null;
            if (!isPanelsOpened)
            {
                InfoPanelViewModel = new CharacterInfoPanelViewModel(SelectedCharacter, FoundSeiyuu);
            }
        }
        private bool CanShowCharacterInfo() => SelectedCharacter != null;

        [RelayCommand(CanExecute = "CanShowResultInfo")]
        public void ShowResultInfo()
        {
            bool isPanelsOpened = InfoPanelViewModel != null;
            InfoPanelViewModel = null;
            if (!isPanelsOpened)
            {
                InfoPanelViewModel = new ResultInfoPanelViewModel(SelectedCharacter, SelectedResult);
            }
        }
        private bool CanShowResultInfo() => SelectedResult != null;
        #endregion

        #region Partial Methods
        partial void OnSelectedAnimeChanged(Anime value)
        {
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
                return;
            }

            FoundSeiyuu = _seiyuuStore.SeiyuuCollection.ToList().Find(s => value.Seiyuu == s.Id);

            if (FoundSeiyuu != null) 
            {
                List<Character> sameCharacters = _characterStore.CharacterCollection.ToList().FindAll(c => FoundSeiyuu.Id == c.Seiyuu);

                foreach (Character character in sameCharacters)
                {
                    List<Anime> characterAnime =  _animeStore.AnimeCollection.ToList().FindAll(a => a.Characters.Contains(character.Id));
                    string shortestTitle = null;

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

        #endregion

        #region Messages
        public void Receive(AnimeCollectionChanged message)
        {
            FilteredAnimeList = new(_animeStore.AnimeCollection);
        }

        public void Receive(CharacterCollectionChanged message)
        {
            FilteredCharacterList = new(_characterStore.CharacterCollection);
        }

        public void Receive(SeiyuuCollectionChanged message)
        {
            
        }
        #endregion
    }
}
