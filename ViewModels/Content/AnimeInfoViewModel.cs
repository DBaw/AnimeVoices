using AnimeVoices.DTO;
using AnimeVoices.Models;
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

        // Currently selected items
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(HideExpandCharactersListCommand))]
        private Anime _selectedAnime;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(HideExpandResultListCommand))]
        private Character _selectedCharacter;
        [ObservableProperty]
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

            List<Character> characters = new List<Character>()
            {
                new Character(1, "Uzumaki Naruto"),
                new Character(2, "Kurosaki Ichigo", 1),
                new Character(3, "L"),
                new Character(4, "Izuku Midorya"),
                new Character(5, "Marco", 1)
            };

            foreach (AnimeDto anime in animeDtoList)
            {
                Anime a = new(anime, LoggedUser);
                _fullAnimeList.Add(a);
            }
            foreach(Character character in characters)
            {
                _fullCharacterList.Add(character);
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
        }
        private bool CanResultListDropDown() => ResultList.Count > 0;
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
            FoundSeiyuu = _fullSeiyuuList.Find(s => value.Seiyuu == s.Id);
            if (FoundSeiyuu != null) 
            {
                foreach(Character character in _fullCharacterList)
                {
                    if(character.Seiyuu == FoundSeiyuu.Id && character.Id != value.Id)
                    {
                        Result result = new("Anime Title", character.Name);
                        ResultList.Add(result);
                    }
                }
            }
        }
        #endregion

    }
}
