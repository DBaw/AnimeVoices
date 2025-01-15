using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.DB;
using AnimeVoices.Models;
using AnimeVoices.Stores;
using Avalonia.Automation.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public class SeiyuuRepository : ISeiyuuRepository
    {
        private readonly IAppDatabase _appDatabase;
        private readonly SeiyuuStore _seiyuuStore;

        public SeiyuuRepository(ISeiyuuApi seiyuuApi, IAppDatabase appDatabase, SeiyuuStore seiyuuStore, SeiyuuDtoStore seiyuuDtoStore, AnimeStore animeStore, CharacterStore characterStore)
        {
            _appDatabase = appDatabase;
            _seiyuuStore = seiyuuStore;
        }

        public async Task InitializeAsync()
        {
            List<SeiyuuEntity> entities = await _appDatabase.GetAllSeiyuuAsync();

            foreach (SeiyuuEntity e in entities)
            {
                await Task.Delay(5);
                Seiyuu seiyuu = SeiyuuMapper.ToModel(e);
                _seiyuuStore.Add(seiyuu);
            }
        }
    }
}
