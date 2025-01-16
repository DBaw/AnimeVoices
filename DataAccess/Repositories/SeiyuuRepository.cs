using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public class SeiyuuRepository : ISeiyuuRepository
    {
        private readonly IAppDatabase _appDatabase;
        private readonly SeiyuuStore _seiyuuStore;

        public SeiyuuRepository(IAppDatabase appDatabase, SeiyuuStore seiyuuStore)
        {
            _appDatabase = appDatabase;
            _seiyuuStore = seiyuuStore;
        }

        public async Task InitializeAsync()
        {
            List<SeiyuuEntity> entities = await _appDatabase.GetAllSeiyuuAsync();

            foreach (SeiyuuEntity e in entities)
            {
                Seiyuu seiyuu = SeiyuuMapper.ToModel(e);
                _seiyuuStore.Add(seiyuu);
            }
        }
    }
}
