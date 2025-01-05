using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public class SeiyuuRepository : ISeiyuuRepository
    {
        private readonly ISeiyuuApi _seiyuuApi;
        private readonly IAppDatabase _appDatabase;
        private readonly SeiyuuStore _seiyuuStore;

        public SeiyuuRepository(ISeiyuuApi seiyuuApi, IAppDatabase appDatabase, SeiyuuStore seiyuuStore)
        {
            _seiyuuApi = seiyuuApi;
            _appDatabase = appDatabase;
            _seiyuuStore = seiyuuStore;
        }

        public async Task InitializeAsync()
        {
            List<SeiyuuEntity> entities = await _appDatabase.GetAllSeiyuuAsync();
            List<Seiyuu> seiyuuList = entities.Select(e => SeiyuuMapper.ToModel(e)).ToList();

            foreach (Seiyuu seiyuu in seiyuuList)
            {
                _seiyuuStore.Add(seiyuu);
            }
        }

        public async Task<Seiyuu> GetSeiyuuByIdAsync(int id)
        {
            var seiyuuDto = await _seiyuuApi.GetSeiyuuByIdAsync(id);
            Seiyuu seiyuu = SeiyuuFactory.Create(seiyuuDto);

            if (!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
            {
                _seiyuuStore.Add(seiyuu);
                await _appDatabase.SaveSeiyuuAsync(SeiyuuMapper.ToEntity(seiyuu));
            }

            return seiyuu;
        }

        public async Task<List<Seiyuu>> GetTopSeiyuuAsync(int page)
        {
            var seiyuuDtos = await _seiyuuApi.GetTopSeiyuuAsync(page);

            var seiyuuModels = new List<Seiyuu>();
            foreach (var seiyuuDto in seiyuuDtos)
            {
                Seiyuu seiyuu = SeiyuuFactory.Create(seiyuuDto);

                if (!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
                {
                    _seiyuuStore.Add(seiyuu);
                    await _appDatabase.SaveSeiyuuAsync(SeiyuuMapper.ToEntity(seiyuu));
                }

                seiyuuModels.Add(seiyuu);
            }

            return seiyuuModels;
        }
    }
}
