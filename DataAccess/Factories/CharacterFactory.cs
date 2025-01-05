using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Factories
{
    public static class CharacterFactory
    {
        public static List<Character> Create(SeiyuuDto dto)
        {
            List<Character> characters = new();
            Dictionary<int, Character> characterDictionary = new();

            foreach (VoiceDto vd in dto.Voices)
            {
                if (!characterDictionary.TryGetValue(vd.Character.Id, out Character existingCharacter))
                {
                    existingCharacter = new Character()
                    {
                        Id = vd.Character.Id,
                        Name = vd.Character.Name,
                        AnimeList = new List<int>(),
                        Seiyuu = dto.Id,
                        ImageUrl = vd.Character.Images?.Jpg.ImageUrl
                    };

                    characterDictionary[vd.Character.Id] = existingCharacter;
                    characters.Add(existingCharacter);
                }

                if (!existingCharacter.AnimeList.Contains(vd.Anime.Id))
                {
                    existingCharacter.AnimeList.Add(vd.Anime.Id);
                }
            }

            return characters;
        }
    }
}
