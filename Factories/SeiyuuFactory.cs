using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;

namespace AnimeVoices.Factories
{
    public static class SeiyuuFactory
    {
        public static Seiyuu Create(SeiyuuDto dto) 
        {
            return new Seiyuu()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
