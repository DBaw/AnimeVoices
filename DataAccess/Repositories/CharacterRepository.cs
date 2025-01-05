using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterStore _characterStore;
        private readonly IAppDatabase _appDatabase;

        public CharacterRepository(CharacterStore characterStore, IAppDatabase appDatabase)
        {
            _characterStore = characterStore;
            _appDatabase = appDatabase;
        }

        public async Task InitializeAsync()
        {
            List<CharacterEntity> entities = await _appDatabase.GetAllCharactersAsync();
            List<Character> characterList = entities.Select(e => CharacterMapper.ToModel(e)).ToList();

            foreach (Character character in characterList)
            {
                _characterStore.Add(character);
            }
        }

        public void SaveCharactersFromSeiyuu(SeiyuuDto dto)
        {
            List<Character> characterList = CharacterFactory.Create(dto);

            foreach (Character character in characterList)
            {
                _characterStore.Add(character);
                _appDatabase.SaveCharacterAsync(CharacterMapper.ToEntity(character));
            }
        }

        public List<Character> GetAllCharacters()
        {
            return _characterStore.CharacterCollection.ToList();
        }
    }
}
