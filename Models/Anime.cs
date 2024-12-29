using AnimeVoices.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Score { get; set; }
        public List<int> Characters { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsOnWatchlist { get; set; }

        public Anime(AnimeDto animeDto, User? user)
        {
            Id = animeDto.Id;
            Title = animeDto.Title;
            Rating = animeDto.Rating == -1 ? "" : ("#" + animeDto.Rating.ToString());
            Score = animeDto.Score == -1  ? "" : animeDto.Score.ToString();
            Characters = string.IsNullOrEmpty(animeDto.CharactersJson) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(animeDto.CharactersJson);

            IsFavourite = user?.FavouriteAnimes.Contains(Id) ?? false;
            IsOnWatchlist = user?.Watchlist.Contains(Id) ?? false;
        }


    }
}
