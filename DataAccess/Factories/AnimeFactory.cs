using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;

namespace AnimeVoices.DataAccess.Factories
{
    public static class AnimeFactory
    {
        public static Anime Create(AnimeDto dto)
        {
            return new Anime
            {
                Id = dto.MalId,
                Title = dto.Title,
                IsFavourite = false,
                IsOnWatchlist = false
            };
        }
    }
}
