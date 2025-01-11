﻿using AnimeVoices.DataAccess.Api;
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
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimeStore _animeStore;
        private readonly IAppDatabase _appDatabase;
        private readonly IAnimeApi _animeApi;

        public AnimeRepository(AnimeStore animeStore, IAppDatabase appDatabase, IAnimeApi animeApi)
        {
            _animeStore = animeStore;
            _appDatabase = appDatabase;
            _animeApi = animeApi;
        }

        public async Task InitializeAsync()
        {
            List<AnimeEntity> entities = await _appDatabase.GetAllAnimeAsync();

            foreach (AnimeEntity e in entities)
            {
                Anime anime = AnimeMapper.ToModel(e);
                _animeStore.Add(anime);
            }
        }

        public async Task SaveAnimeFromSeiyuu(SeiyuuDto dto)
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
                        _animeStore.Update(existingAnime);
                        await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(existingAnime));
                    }
                }
                else
                {
                    _animeStore.Add(anime);
                    await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(anime));
                }

            }
        }

        public List<Anime> GetAllAnime()
        {
            return _animeStore.AnimeCollection.ToList();
        }

        public async Task<Anime> GetAnimeByIdAsync(int id)
        {
            SingleAnimeDto singleAnimeDto = await _animeApi.GetAnimeByIdAsync(id);
            // TODO: Get anime data - save it in store and database
            return new Anime();
        }
    }
}
