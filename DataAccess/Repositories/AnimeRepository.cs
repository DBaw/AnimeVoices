﻿using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
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
        private readonly CharacterStore _characterStore;
        private readonly SeiyuuStore _seiyuuStore;
        private readonly IAppDatabase _appDatabase;
        private readonly IAnimeApi _animeApi;

        public AnimeRepository(AnimeStore animeStore, CharacterStore characterStore, SeiyuuStore seiyuuStore, IAppDatabase appDatabase, IAnimeApi animeApi)
        {
            _animeStore = animeStore;
            _characterStore = characterStore;
            _seiyuuStore = seiyuuStore;
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

        public async Task<Anime> GetAnimeByIdAsync(int id)
        {
            SingleAnimeDto singleAnimeDto = await _animeApi.GetAnimeByIdAsync(id);
            // TODO: Get anime data - save it in store and database
            return new Anime();
        }

        public async Task GetTopAnimeAsync(int page)
        {
            // Fetch top anime data from API
            var topAnimeDto = await _animeApi.GetTopAnimeAsync(page);
            var animeList = topAnimeDto.AnimeDto;

            foreach (var animeDto in animeList)
            {
                // Fetch anime characters with a 1s delay between each call
                await Task.Delay(1000);
                await GetAnimeCharactersAsync(animeDto);
            }
        }

        public async Task GetAnimeCharactersAsync(AnimeDto dto)
        {
            var animeCharactersDto = await _animeApi.GetAnimeCharactersAsync(dto.Id);

            var anime = AnimeFactory.Create(dto);
            List<Character> charactersList = new();
            List<Seiyuu> seiyuuList = new();

            foreach(AnimeCharactersDto acDto in animeCharactersDto.AnimeCharacters)
            {
                SeiyuuDto seiyuuDto = new();
                Seiyuu seiyuu = new ();
                Character character = new();

                if(acDto.SeiyuuList != null && acDto.Favorites > 40)
                {
                    foreach (VoiceActorDto actor in acDto.SeiyuuList)
                    {
                        if (actor.Language == "Japanese")
                        {
                            seiyuuDto = actor.SeiyuuDto;
                            break;
                        }
                    }
                    if (seiyuuDto.Id != null)
                    {
                        character = CharacterFactory.Create(acDto.Character, seiyuuDto.Id);
                        charactersList.Add(character);

                        if(!_characterStore.CharacterCollection.Any(c => c.Id == acDto.Character.Id))
                        {
                            _characterStore.CharacterCollection.Add(character);
                        }

                        if(!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuuDto.Id))
                        {
                            seiyuu = SeiyuuFactory.Create(seiyuuDto);
                            _seiyuuStore.Add(seiyuu);

                        }
                    }
                }

            }

            foreach (Character c in charactersList)
            {
                anime.Characters.Add(c.Id);
            }

            if (!_animeStore.AnimeCollection.Any(a => a.Id == anime.Id))
            {
                _animeStore.Add(anime);
            }
        }

        public List<Anime> GetAllAnime()
        {
            throw new System.NotImplementedException();
        }
    }
}
