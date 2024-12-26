using AnimeVoices.DTO;
using AnimeVoices.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AnimeVoices.ViewModels.Content
{
    public partial class AnimeInfoViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isFavorite;

        [ObservableProperty]
        private bool _isOnWatchlist;

        [ObservableProperty]
        private ObservableCollection<Anime> _animeList;

        public AnimeInfoViewModel()
        {
            IsFavorite = false;
            IsOnWatchlist = true;

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
            List<int> favAnime = new List<int>() { 1, 3 };
            List<int> watchlist = new List<int>() { 4 };
            User user = new(1, favAnime, watchlist);

            foreach (AnimeDto anime in animeDtoList)
            {
                Anime a = new(anime, user);
                AnimeList.Add(a);
            }
        }

    }
}
