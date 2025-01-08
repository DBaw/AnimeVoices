using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using System;
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

            foreach (SeiyuuEntity e in entities)
            {
                await Task.Delay(50);
                Seiyuu seiyuu = SeiyuuMapper.ToModel(e);
                _seiyuuStore.Add(seiyuu);
            }
        }

        public async Task<Seiyuu> GetSeiyuuByIdAsync(int id)
        {
            SeiyuuDto seiyuuDto = new();
            if (_seiyuuDtoStore.Contains(id))
            {
                seiyuuDto = _seiyuuDtoStore.Get(id);
                return SeiyuuFactory.Create(seiyuuDto);
            }

            var responseFromApi = await _seiyuuApi.GetSeiyuuByIdAsync(id);
            seiyuuDto = responseFromApi.SeiyuuDto;
            _seiyuuDtoStore.Add(seiyuuDto);

            var seiyuu = SeiyuuFactory.Create(seiyuuDto);

            if (!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
            {
                _seiyuuStore.Add(seiyuu);
                await _appDatabase.SaveSeiyuuAsync(SeiyuuMapper.ToEntity(seiyuu));
            }

            return seiyuu;
        }

        public async Task<List<Seiyuu>> GetTopSeiyuuAsync(int page)
        {
            var topSeiyuu = await _seiyuuApi.GetTopSeiyuuAsync(page);
            List<SeiyuuDto> dtos = topSeiyuu.Data;

            var seiyuuModels = new List<Seiyuu>();
            foreach (var seiyuuDto in dtos)
            {
                await Task.Delay(1000);
                var fullSeiyuu = await GetSeiyuuByIdAsync(seiyuuDto.Id);
                seiyuuModels.Add(fullSeiyuu);
            }

            return seiyuuModels;
        }
    }
}
