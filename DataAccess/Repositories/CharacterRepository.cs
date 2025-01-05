using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        public List<Character> GetAllCharacters(List<CharacterEntity> entities)
        {
            List<Character> result = new();

            foreach (CharacterEntity entity in entities)
            {
                Character character = CharacterMapper.ToModel(entity);
                result.Add(character);
            }

            return result;
        }

        public List<Character> GetCharactersFromSeiyuu(SeiyuuDto dto)
        {
            return CharacterFactory.Create(dto);
        }
    }
}
