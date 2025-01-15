using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;
using System.Linq;

namespace AnimeVoices.DataAccess.Factories
{
    public static class AnimeFactory
    {
        public static Anime Create(AnimeDto dto)
        {

            return new Anime
            {
                Id = dto.Id,
                Title = string.IsNullOrEmpty(dto.Title) ? "unknown" : dto.Title,
                Episodes = dto?.Episodes == null ? "unknown" : dto.Episodes.ToString(),
                Status = string.IsNullOrEmpty(dto.Status) ? "unknown" : dto.Status,
                Aired = dto?.Aired?.Period == null ? "unknown" : dto.Aired.Period,
                Score = dto?.Score == null ? "unknown" : dto.Score.ToString(),
                Characters = new(),
                Rating = string.IsNullOrEmpty(dto.Rating) ? "unknown" : dto.Rating,
                Studio = dto.Studios == null ? "unknown" : string.Join(" and ", dto.Studios.Select(s => s.Name)),
                About = string.IsNullOrEmpty(dto.About) ? "unknown" : dto.About,
                Broadcast = dto.Broadcast?.FullTime == null ? "unknown" : dto.Broadcast.FullTime,
                IsFavourite = false,
                IsOnWatchlist = false,
            };  
        }
    }
}