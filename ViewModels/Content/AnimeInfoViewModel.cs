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
        private Anime _selectedAnime;

        [ObservableProperty]
        private int _maxAnimeListHeight;
        [ObservableProperty]
        private bool _animeListExpanded;

        [ObservableProperty]
        private bool _isUserLoggedIn;

        [ObservableProperty]
        private User _loggedUser;

        public AnimeInfoViewModel(User user)
        {
            LoggedUser = user;
            AnimeListExpanded = false;
            MaxAnimeListHeight = 0;
            IsUserLoggedIn = LoggedUser != null;
            FilteredAnimeList = new ObservableCollection<Anime>();

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

            foreach (AnimeDto anime in animeDtoList)
            {
                Anime a = new(anime, LoggedUser);
                FilteredAnimeList.Add(a);
            }
            FullAnimeList = FilteredAnimeList;
        }

        [RelayCommand]
        public void DropExpandAnimeList()
        {
            int height = 100;
            FilteredAnimeList = new ObservableCollection<Anime>(FullAnimeList);
            if (AnimeListExpanded)
            {
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

    }
}
