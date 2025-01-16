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
                EngTitle = entity.EngTitle,
                Rating = entity.Rating,
                Score = entity.Score == -1 ? "unknown" : entity.Score.ToString(),
                Studio = entity.Studio,
                Aired = entity.Aired,
                Status = entity.Status,
                About = entity.Synopsis,
                Episodes = entity.Episodes == -1 ? "unknown" : entity.Episodes.ToString(),
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
                EngTitle = model.EngTitle,
                Rating = model.Rating,
                Score = model.Score == "unknown" ? -1 : double.Parse(model.Score),
                Studio = model.Studio,
                Aired = model.Aired,
                Status = model.Status,
                Synopsis = model.About,
                Episodes = model.Episodes == "unknown" ? -1 : int.Parse(model.Episodes),
                Characters = string.Join(",", model.Characters)
            };
        }
    }
}
