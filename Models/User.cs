using AnimeVoices.DTO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnimeVoices.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<int> FavouriteAnimes { get; set; }
        public List<int> FavouritesSeiyuus { get; set; }
        public List<int> Watchlist { get; set; }

        public User(UserDto userDto)
        {
            Id = userDto.Id;
            Name = userDto.Name;
            Password = userDto.Password;
            FavouriteAnimes = userDto.FavouriteAnimesJson == null ? new() : JsonConvert.DeserializeObject<List<int>>(userDto.FavouriteAnimesJson);
            FavouritesSeiyuus = userDto.FavouritesSeiyuusJson == null ? new() : JsonConvert.DeserializeObject<List<int>>(userDto.FavouritesSeiyuusJson);
            Watchlist = userDto.Watchlist == null ? new() : JsonConvert.DeserializeObject<List<int>>(userDto.Watchlist);
        }

        public User(int id, List<int> favAnime, List<int> watchlist)
        {
            Id = id;
            FavouriteAnimes = favAnime;
            Watchlist = watchlist;
        }
    }
}
