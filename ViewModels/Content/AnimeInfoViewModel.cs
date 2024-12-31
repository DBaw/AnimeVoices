using AnimeVoices.DTO;
using AnimeVoices.Models;
using AnimeVoices.ViewModels.Content.InfoPanels;
using AnimeVoices.Views.Content.InfoPanels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AnimeInfoViewModel : ObservableObject
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
        public AnimeInfoViewModel(User user)
        {
            LoggedUser = user;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = true;
            CharacterListExpanded = false;
            ResultListExpanded = false;

            _fullAnimeList = new List<Anime>();
            _fullCharacterList = new List<Character>();

            List<int> seiyuuChars = new List<int>() { 2,5 };
            _fullSeiyuuList = new List<Seiyuu>()
            {
                new Seiyuu(1, seiyuuChars)
            };


            List<AnimeDto> animeDtoList = new List<AnimeDto>()
            {
                new AnimeDto(1,"Naruto", 12, 8.88, "[1]"),
                new AnimeDto(2,"Bleach", 29, 8.65, "[2]"),
                new AnimeDto(3,"Noragami", 258, 8.02),
                new AnimeDto(4,"Kimetsu no Yayba", 5, 9.21),
                new AnimeDto(5,"One Piece", 7, 9.01,"[5]")
            };

            List<CharacterDto> charactersDtoList = new List<CharacterDto>()
            {
                new CharacterDto(1, "Uzumaki Naruto", "[1]", -1),
                new CharacterDto(2, "Kurosaki Ichigo", "[2]",  1),
                new CharacterDto(3, "L", "[-1]", -1),
                new CharacterDto(4, "Izuku Midorya", "[-1]", -1),
                new CharacterDto(5, "Marco","[5]", 1)
            };

            foreach (AnimeDto anime in animeDtoList)
            {
                Anime a = new(anime, LoggedUser);
                _fullAnimeList.Add(a);
            }
            foreach(CharacterDto characterDto in charactersDtoList)
            {
                Character c = new(characterDto);
                _fullCharacterList.Add(c);
            }
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
            if(InfoPanelViewModel == null) 
            {  
                InfoPanelViewModel = new AnimeInfoPanelViewModel(SelectedAnime); 
            }
            else
            {
                InfoPanelViewModel = null;
            }
        }
        private bool CanShowAnimeInfo() => SelectedAnime != null;

        [RelayCommand(CanExecute = "CanShowCharacterInfo")]
        public void ShowCharacterInfo()
        {
        }
        private bool CanShowCharacterInfo() => SelectedCharacter != null;

        [RelayCommand(CanExecute = "CanShowResultInfo")]
        public void ShowResultInfo()
        {
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
                        Result result = new(animeTitle, character.Name);
                        ResultList.Add(result);
                    }
                }
            }
        }
        #endregion

    }
}
