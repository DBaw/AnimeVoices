using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;

namespace AnimeVoices.Factories
{
    public static class CharacterFactory
    {
        public static Character Create(CharacterDto dto)
        {
            return new Character
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
