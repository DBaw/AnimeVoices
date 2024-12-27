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

        [ObservableProperty]
        private ObservableCollection<Anime> _fullAnimeList;
        [ObservableProperty]
        private ObservableCollection<Anime> _filteredAnimeList;

        [ObservableProperty]
        private ObservableCollection<Character> _fullCharacterList;
        [ObservableProperty]
        private ObservableCollection<Character> _filteredCharacterList;

        [ObservableProperty]
        private ObservableCollection<Seiyuu> _seiyuuList;

        [ObservableProperty]
        private Anime _selectedAnime;
        [ObservableProperty]
        private Character _selectedCharacter;
        [ObservableProperty]
        private Seiyuu _selectedSeiyuu;

        [ObservableProperty]
        private int _maxAnimeListHeight;
        [ObservableProperty]
        private bool _animeListExpanded;

        [ObservableProperty]
        private int _maxCharacterListHeight;
        [ObservableProperty]
        private bool _characterListExpanded;

        [ObservableProperty]
        private int _maxSeiyuuListHeight;
        [ObservableProperty]
        private bool _seiyuuListExpanded;

        [ObservableProperty]
        private bool _isUserLoggedIn;

        [ObservableProperty]
        private User _loggedUser;

        public AnimeInfoViewModel(User user)
        {
            LoggedUser = user;
            IsUserLoggedIn = LoggedUser != null;

            AnimeListExpanded = false;
            CharacterListExpanded = false;
            SeiyuuListExpanded = false;

            MaxAnimeListHeight = 0;
            MaxCharacterListHeight = 0;
            MaxSeiyuuListHeight = 0;

            FullAnimeList = new ObservableCollection<Anime>();
            FullCharacterList = new ObservableCollection<Character>();
            SeiyuuList = new ObservableCollection<Seiyuu>();

            List<AnimeDto> animeDtoList = new List<AnimeDto>()
            {
                new AnimeDto()
                {
                    Id = 1,
                    Title = "Naruto",
                    Rating = 12,
                    Score = 8.88
                },
                new AnimeDto()
                {
                    Id = 2,
                    Title = "Bleach",
                    Rating = 29,
                    Score = 8.65
                },
                new AnimeDto()
                {
                    Id = 3,
                    Title = "Noragami",
                    Rating = 258,
                    Score = 8.02
                },
                new AnimeDto()
                {
                    Id = 4,
                    Title = "Kimetsu No Yayba",
                    Rating = 5,
                    Score = 9.21
                }
            };

            List<Character> characters = new List<Character>()
            {
                new Character(1,"Uzumaki Naruto"),
                new Character(1,"Kurosaki Ichigo")
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
            FilteredCharacterList = new(FullCharacterList);
        }

        [RelayCommand(CanExecute = "CanAnimeListDropDown")]
        public void DropExpandAnimeList()
        {
            int height = 100;
            FilteredAnimeList = new ObservableCollection<Anime>(FullAnimeList);
            if (AnimeListExpanded)
            {
                MaxAnimeListHeight = height;
                if (SelectedAnime != null)
                {
                    height = 25;
                    FilteredAnimeList = new ObservableCollection<Anime> { SelectedAnime };
                }
                else
                {
                    height = 0;
                }
            }
            MaxAnimeListHeight = height;
            AnimeListExpanded = !AnimeListExpanded;
        }
        private bool CanAnimeListDropDown() => FilteredAnimeList.Count > 0;

        [RelayCommand(CanExecute = "CanCharacterListDropDown")]
        public void DropExpandCharactersList()
        {
            int height = 100;
            FilteredCharacterList = new ObservableCollection<Character>(FullCharacterList);
            if (CharacterListExpanded)
            {
                if (SelectedCharacter != null)
                {
                    height = 25;
                    FilteredCharacterList = new ObservableCollection<Character> { SelectedCharacter };
                }
                else
                {
                    height = 0;
                }
            }
            MaxCharacterListHeight = height;
            CharacterListExpanded = !CharacterListExpanded;
        }
        private bool CanCharacterListDropDown() => FilteredCharacterList.Count > 0;


    }
}
