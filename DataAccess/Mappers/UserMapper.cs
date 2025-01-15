using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Linq;

namespace AnimeVoices.DataAccess.Mappers
{
    public static class UserMapper
    {
        public static User ToModel(UserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                FavouriteAnimes = string.IsNullOrEmpty(entity.FavouriteAnimes) ? new() : entity.FavouriteAnimes.Split(',').ToList().Select(int.Parse).ToList(),
                FavouritesSeiyuus = string.IsNullOrEmpty(entity.FavouritesSeiyuus) ? new() : entity.FavouritesSeiyuus.Split(',').ToList().Select(int.Parse).ToList(),
                Watchlist = string.IsNullOrEmpty(entity.Watchlist) ? new() : entity.Watchlist.Split(',').ToList().Select(int.Parse).ToList()
            };
        }

        public static UserEntity ToEntity(User model)
        {
            return new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Password = model.Password,
                FavouriteAnimes = string.Join(",", model.FavouriteAnimes),
                FavouritesSeiyuus = string.Join(",", model.FavouritesSeiyuus),
                Watchlist = string.Join(",", model.Watchlist)
            };
        }
    }
}
