using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels
{
    public class AnimeDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public double Score { get; set; }
        public string Studio {  get; set; }
        public string Aired { get; set; }
        public string Status { get; set; }
        public string Synopsis { get; set; }
        public int Episodes { get; set; }
        public string CharactersJson { get; set; }

        public AnimeDto()
        {
            
        }
        public AnimeDto(int id, string title, int rating, double score)
        {
            Id = id;
            Title = title;
            Rating = rating;
            Score = score;
            CharactersJson = String.Empty;
            Studio = "Studio";
            Status = "Ended";
            Aired = "Jan 2, 2019 to Dec 19, 2020";
            Synopsis = "Anime about something";
            Episodes = 3;
        }
        public AnimeDto(int id, string title, int rating, double score, string characters) 
        {
            Id = id;
            Title = title;  
            Rating = rating;
            Score = score;
            CharactersJson = String.IsNullOrEmpty(characters) ? String.Empty : characters;
            Studio = "Ghibi";
            Status = "Currently Airing";
            Aired = "Oct 20, 1999 to ?";
            Synopsis = "Anime about something";
            Episodes = 2358;
        }
    }
}
