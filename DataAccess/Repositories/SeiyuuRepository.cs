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
        private readonly SeiyuuDtoStore _seiyuuDtoStore;

        public SeiyuuRepository(ISeiyuuApi seiyuuApi, IAppDatabase appDatabase, SeiyuuStore seiyuuStore, SeiyuuDtoStore seiyuuDtoStore)
        {
            _seiyuuApi = seiyuuApi;
            _appDatabase = appDatabase;
            _seiyuuStore = seiyuuStore;
            _seiyuuDtoStore = seiyuuDtoStore;
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
            if (_seiyuuDtoStore.Contains(id))
            {
                var seiyuuDto = _seiyuuDtoStore.Get(id);
                return SeiyuuFactory.Create(seiyuuDto);
            }

            var seiyuuDtoFromApi = await _seiyuuApi.GetSeiyuuByIdAsync(id);
            _seiyuuDtoStore.Add(seiyuuDtoFromApi);

            var seiyuu = SeiyuuFactory.Create(seiyuuDtoFromApi);

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
                if (!_seiyuuDtoStore.Contains(seiyuuDto.Id))
                {
                    _seiyuuDtoStore.Add(seiyuuDto);
                }
                await Task.Delay(400);
                var fullSeiyuu = await GetSeiyuuByIdAsync(seiyuuDto.Id);
                seiyuuModels.Add(fullSeiyuu);
            }

            return seiyuuModels;
        }
    }
}
