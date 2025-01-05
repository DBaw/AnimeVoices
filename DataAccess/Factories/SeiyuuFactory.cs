using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Factories
{
    public static class SeiyuuFactory
    {
        public static Seiyuu Create(SeiyuuDto dto)
        {
            Seiyuu seiyuu = new Seiyuu()
            {
                Id = dto.Id,
                Name = dto.Name,
                ImageUrl = dto.Images?.Jpg.ImageUrl,
                Characters = new List<int>(),
            };

            foreach (VoiceDto vd in dto.Voices)
            {
                if (!seiyuu.Characters.Contains(vd.Character.Id))
                {
                    seiyuu.Characters.Add(vd.Character.Id);
                }
            }

            return seiyuu;
        }
    }
}
