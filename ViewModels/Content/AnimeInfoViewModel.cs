using AnimeVoices.DTO;
using AnimeVoices.Models;
using CommunityToolkit.Mvvm.ComponentModel;
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
        private bool _isUserLoggedIn;

        [ObservableProperty]
        private User _loggedUser;

        public AnimeInfoViewModel(User user)
        {
            LoggedUser = user;
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
        }

    }
}
