using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface ICharacterRepository
    {
        public List<Character> GetCharactersFromSeiyuu(SeiyuuDto dto);
        public List<Character> GetAllCharacters(List<CharacterEntity> entities);
    }
}
