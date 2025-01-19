using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Factories
{
    public static class CharacterFactory
    {
        public static Character Create(CharacterDto dto, int seiyuuId)
        {
            return new Character
            {
                Id = dto.Id,
                Name = dto.Name,
                Seiyuu = seiyuuId,
                ImageUrl = string.IsNullOrEmpty(dto.Images.Jpg.ImageUrl) ? "" : dto.Images.Jpg.ImageUrl,
            };
        }
    }
}
