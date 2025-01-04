using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;

namespace AnimeVoices.Factories
{
    public static class AnimeFactory
    {
        public static Anime Create(AnimeDto dto)
        {
            return new Anime
            {
                Id = dto.Id,
                Title = dto.Title,
                IsFavourite = false,
                IsOnWatchlist = false
            };
        }
    }
}
