using AnimeVoices.Models;
using AnimeVoices.Utilities.Helpers;
using AnimeVoices.ViewModels.Content.InfoPanels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AnimeInfoViewModel : BaseViewModel
    {
        #region Parameters
        // Full and filtered data
        private List<Anime> _fullAnimeList;
        private List<Character> _fullCharacterList;
        private List<Seiyuu> _fullSeiyuuList;
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
        #endregion

        #region Constructors
        public AnimeInfoViewModel(IMessenger messenger) : base(messenger)
        {
            LoggedUser = null;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = true;
            CharacterListExpanded = false;
            ResultListExpanded = false;

            _fullAnimeList = new List<Anime>();
            _fullCharacterList = new List<Character>();

            FilteredAnimeList = new(_fullAnimeList);
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

            foreach (var character in _fullCharacterList)
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

            FoundSeiyuu = _fullSeiyuuList.Find(s => value.Seiyuu == s.Id);

            if (FoundSeiyuu != null) 
            {
                foreach(Character character in _fullCharacterList)
                {
                    if(character.Seiyuu == FoundSeiyuu.Id && character.Id != value.Id)
                    {
                        List<Anime> charactersAnime= _fullAnimeList.FindAll(a => character.AnimeList.Contains(a.Id));
                        string animeTitle = "";
                        foreach(Anime anime in charactersAnime)
                        {
                            if (anime.Characters.Contains(character.Id))
                            {
                                animeTitle = anime.Title;
                                break;
                            }
                        }
                        Result result = new(animeTitle, character.Name, ImageHelper.LoadImage(character.ImageUrl));
                        ResultList.Add(result);
                    }
                }
            }
        }
        #endregion

    }
}
