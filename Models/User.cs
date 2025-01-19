using System.Collections.Generic;
using Newtonsoft.Json;
using AnimeVoices.DataModels.Entities;

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

        public User() { }
    }
}
