using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
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
        private readonly IAnimeDatabase _animeDatabase;

        public AnimeRepository(AnimeStore animeStore, IAnimeDatabase animeDatabase)
        {
            _animeStore = animeStore;
            _animeDatabase = animeDatabase;
        }

        public async Task InitializeAsync()
        {
            var entities = await _animeDatabase.GetAllAnimeAsync();
            var animeList = entities.Select(AnimeMapper.ToModel).ToList();

            foreach (var anime in animeList)
            {
                _animeStore.Add(anime);
            }
        }

        public void SaveAnimeFromSeiyuu(SeiyuuDto dto)
        {
            var animeList = AnimeFactory.Create(dto);

            foreach (var anime in animeList)
            {
                // Add to store
                _animeStore.Add(anime);

                // Persist to database
                _animeDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(anime));
            }
        }

        public List<Anime> GetAllAnime()
        {
            return _animeStore.AnimeCollection.ToList();
        }
    }
}
