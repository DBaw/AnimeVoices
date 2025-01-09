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

            foreach (AnimeEntity e in entities)
            {
                await Task.Delay(50);
                Anime anime = AnimeMapper.ToModel(e);
                _animeStore.Add(anime);
            }
        }

        public void SaveAnimeFromSeiyuu(SeiyuuDto dto)
        {
            List<Anime> animeList = AnimeFactory.Create(dto);

            foreach (Anime anime in animeList)
            {
                Anime existingAnime = _animeStore.AnimeCollection.FirstOrDefault(a => a.Id == anime.Id);

                if (existingAnime != null)
                {
                    bool updated = false;

                    foreach (int characterId in anime.Characters)
                    {
                        if (!existingAnime.Characters.Contains(characterId))
                        {
                            existingAnime.Characters.Add(characterId);
                            updated = true;
                        }
                    }
                    
                    if (updated)
                    {
                        _appDatabase.UpdateAnimeAsync(AnimeMapper.ToEntity(existingAnime));
                    }
                }
                else
                {
                    _animeStore.Add(anime);

                    _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(anime));
                }
            }
        }

        public List<Anime> GetAllAnime()
        {
            return _animeStore.AnimeCollection.ToList();
        }
    }
}
