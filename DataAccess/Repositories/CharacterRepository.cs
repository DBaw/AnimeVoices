using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using System.Collections.Generic;
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

            foreach (CharacterEntity e in entities)
            {
                Character character = CharacterMapper.ToModel(e);
                _characterStore.Add(character);
            }
        }
    }
}
