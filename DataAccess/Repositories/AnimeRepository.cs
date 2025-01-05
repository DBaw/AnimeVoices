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
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeStore _animeStore;
        private readonly IAppDatabase _appDatabase;

        public AnimeRepository(AnimeStore animeStore, IAppDatabase appDatabase)
        {
            _animeStore = animeStore;
            _appDatabase = appDatabase;
        }

        public async Task InitializeAsync()
        {
            List<AnimeEntity> entities = await _appDatabase.GetAllAnimeAsync();
            List<Anime> animeList = entities.Select(e => AnimeMapper.ToModel(e)).ToList();

            foreach (Anime anime in animeList)
            {
                _animeStore.Add(anime);
            }
        }

        public void SaveAnimeFromSeiyuu(SeiyuuDto dto)
        {
            List<Anime> animeList = AnimeFactory.Create(dto);

            foreach (Anime anime in animeList)
            {
                _animeStore.Add(anime);

                _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(anime));
            }
        }

        public List<Anime> GetAllAnime()
        {
            return _animeStore.AnimeCollection.ToList();
        }
    }
}
