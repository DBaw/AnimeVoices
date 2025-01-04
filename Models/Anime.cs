using AnimeVoices.DataModels.DTOs;
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
        public string Studio { get; set; }
        public string Aired { get; set; }
        public string Status { get; set; }
        public string Synopsis { get; set; }
        public string Episodes { get; set; }
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
            Studio = animeDto.Studio;
            Aired = animeDto.Aired;
            Status = animeDto.Status;
            Synopsis = animeDto.Synopsis;
            Episodes = animeDto.Episodes.ToString();

            IsFavourite = user?.FavouriteAnimes.Contains(Id) ?? false;
            IsOnWatchlist = user?.Watchlist.Contains(Id) ?? false;
        }


    }
}
