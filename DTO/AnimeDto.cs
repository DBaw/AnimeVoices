using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class AnimeDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public double Score { get; set; }
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
        }
        public AnimeDto(int id, string title, int rating, double score, string characters) 
        {
            Id = id;
            Title = title;  
            Rating = rating;
            Score = score;
            CharactersJson = String.IsNullOrEmpty(characters) ? String.Empty : characters;
        }
    }
}
