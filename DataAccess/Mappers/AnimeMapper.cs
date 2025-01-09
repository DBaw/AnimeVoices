using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Linq;

namespace AnimeVoices.DataAccess.Mappers
{
    public static class AnimeMapper
    {
        public static Anime ToModel(AnimeEntity entity, User user = null)
        {
            return new Anime
            {
                Id = entity.Id,
                Title = entity.Title,
                /*
                Rating = entity.Rating,
                Score = entity.Score.ToString(),
                Studio = entity.Studio,
                Aired = entity.Aired,
                Status = entity.Status,
                Synopsis = entity.Synopsis,
                Episodes = entity.Episodes.ToString(),
                */
                Characters = string.IsNullOrEmpty(entity.Characters) ? new() : entity.Characters.Split(',').ToList().Select(int.Parse).ToList(),
                IsFavourite = user == null ? false : user.FavouriteAnimes.Contains(entity.Id),
                IsOnWatchlist = user == null ? false : user.Watchlist.Contains(entity.Id),
            };
        }

        public static AnimeEntity ToEntity(Anime model)
        {
            return new AnimeEntity
            {
                Id = model.Id,
                Title = model.Title,
                Rating = "",
                Score = -1,
                Studio = "",
                Aired = "",
                Status = "",
                Synopsis = "",
                Episodes = -1,
                Characters = string.Join(",", model.Characters)
            };
        }
    }
}
