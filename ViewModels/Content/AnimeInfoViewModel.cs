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
        [ObservableProperty] private ObservableCollection<Anime> _fullAnimeList;
        [ObservableProperty] private ObservableCollection<Anime> _filteredAnimeList;
        [ObservableProperty] private ObservableCollection<Character> _fullCharacterList;
        [ObservableProperty] private ObservableCollection<Character> _filteredCharacterList;
        [ObservableProperty] private ObservableCollection<Seiyuu> _seiyuuList;

        // Currently selected items
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(HideExpandCharactersListCommand))]
        private Anime _selectedAnime;
        [ObservableProperty] 
        private Character _selectedCharacter;
        [ObservableProperty] 
        private Seiyuu _selectedSeiyuu;

        // UI control properties
        [ObservableProperty] private int _maxAnimeListHeight;
        [ObservableProperty] private int _maxCharacterListHeight;
        [ObservableProperty] private int _maxSeiyuuListHeight;
        [ObservableProperty] private bool _animeListExpanded;
        [ObservableProperty] private bool _characterListExpanded;
        [ObservableProperty] private bool _seiyuuListExpanded;
        [ObservableProperty] private bool _isSelectedAnimeVisible;
        [ObservableProperty] private bool _isSelectedCharacterVisible;

        // User login state
        [ObservableProperty] private bool _isUserLoggedIn;
        [ObservableProperty] private User _loggedUser;

        // Additional local variables
        private int maxListHeight = 200;
        private int hidedListHeight = 0;
        #endregion

        #region Constructors
        public AnimeInfoViewModel(User user)
        {
            LoggedUser = user;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = true;
            CharacterListExpanded = false;
            SeiyuuListExpanded = false;
            IsSelectedAnimeVisible = false;
            IsSelectedCharacterVisible = false;

            MaxAnimeListHeight = 100;
            MaxCharacterListHeight = 0;
            MaxSeiyuuListHeight = 0;

            FullAnimeList = new ObservableCollection<Anime>();
            FullCharacterList = new ObservableCollection<Character>();
            SeiyuuList = new ObservableCollection<Seiyuu>();

            List<AnimeDto> animeDtoList = new List<AnimeDto>()
            {
                new AnimeDto(1,"Naruto", 12, 8.88, "[1]"),
                new AnimeDto(2,"Bleach", 29, 8.65, "[2]"),
                new AnimeDto(3,"Noragami", 258, 8.02),
                new AnimeDto(4,"Kimetsu no Yayba", 5, 9.21)
            };

            List<Character> characters = new List<Character>()
            {
                new Character(1, "Uzumaki Naruto"),
                new Character(2, "Kurosaki Ichigo"),
                new Character(3, "L"),
                new Character(4, "Izuku Midorya"),
            };

            foreach (AnimeDto anime in animeDtoList)
            {
                Anime a = new(anime, LoggedUser);
                FullAnimeList.Add(a);
            }
            foreach(Character character in characters)
            {
                FullCharacterList.Add(character);
            }
            FilteredAnimeList = new(FullAnimeList);
            FilteredCharacterList = new();
        }
        #endregion

        #region Commands
        [RelayCommand(CanExecute = "CanAnimeListDropDown")]
        public void HideExpandAnimeList(string list)
        {
            CharacterListExpanded = false;
            MaxCharacterListHeight = hidedListHeight;

            if (AnimeListExpanded)
            {
                MaxAnimeListHeight = hidedListHeight;
            }
            else
            {
                MaxAnimeListHeight = maxListHeight;
                IsSelectedAnimeVisible = false;
                if(SelectedCharacter != null)
                {
                    IsSelectedCharacterVisible = true;
                }
            }
            if (AnimeListExpanded && SelectedAnime != null) 
            {
                IsSelectedAnimeVisible = true;
            }
            AnimeListExpanded = !AnimeListExpanded;
        }
        private bool CanAnimeListDropDown() => FilteredAnimeList.Count > 0;

        [RelayCommand(CanExecute = "CanCharacterListDropDown")]
        public void HideExpandCharactersList(string list)
        {
            AnimeListExpanded = false;
            MaxAnimeListHeight = hidedListHeight;

            if (CharacterListExpanded)
            {
                MaxCharacterListHeight = hidedListHeight;
            }
            else
            {
                MaxCharacterListHeight = maxListHeight;
                IsSelectedCharacterVisible = false;
                IsSelectedAnimeVisible = true;
            }
            if (CharacterListExpanded && SelectedCharacter != null)
            {
                IsSelectedCharacterVisible = true;
            }
            CharacterListExpanded = !CharacterListExpanded;
            
        }
        private bool CanCharacterListDropDown() => FilteredCharacterList.Count > 0;
        #endregion

        #region Partial Methods
        partial void OnSelectedAnimeChanged(Anime value)
        {
            IsSelectedCharacterVisible = false;
            FilteredCharacterList.Clear();
            if (value == null)
            {
                return;
            }

            // Filter characters by selected anime
            foreach (var character in FullCharacterList)
            {
                if (value.Characters.Contains(character.Id))
                {
                    FilteredCharacterList.Add(character);
                }
            }
        }
        #endregion

    }
}
