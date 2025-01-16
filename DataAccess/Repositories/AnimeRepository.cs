using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
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
            var singleAnimeDto = await _animeApi.GetAnimeByIdAsync(id);
            var animeDto = singleAnimeDto.AnimeDto;

            Anime anime = AnimeFactory.Create(animeDto);
            return anime;
        }

        public async Task GetTopAnimeAsync()
        {
            string properties = "";

            // Get Page for selected properies
            AnimePaginationEntity paginationEntity = await _appDatabase.GetTopAnimePagination(properties);
            AnimePagination pagination = AnimePaginationMapper.ToModel(paginationEntity);
            pagination.Page ++;

            // Fetch top anime data from API
            TopAnimeDto topAnimeDto = new();
            List<AnimeDto> animeList = new(); 
            try
            {
                topAnimeDto = await _animeApi.GetTopAnimeAsync(pagination);
                animeList = topAnimeDto.AnimeDto;
            } catch (Exception ex)
            {
                return;
            }

            foreach (var animeDto in animeList)
            {
                // Fetch anime characters with a 1s delay between each call for character not already in the store
                if(!_animeStore.AnimeCollection.Any(a => a.Id == animeDto.Id))
                {
                    try
                    {
                        await Task.Delay(1000);
                        await GetAnimeCharactersAsync(animeDto);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            // Save current pagination to database
            var paginationDto = topAnimeDto.PaginationDto;
            var paginationFromDto = AnimePaginationFactory.Create(paginationDto, properties);
            var paginationEntityFromDto = AnimePaginationMapper.ToEntity(paginationFromDto);
            await _appDatabase.SaveAnimePaginationAsync(paginationEntityFromDto);
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
                    if (seiyuuDto?.Name != null)
                    {
                        character = CharacterFactory.Create(acDto.Character, seiyuuDto.Id);
                        charactersList.Add(character);

                        if(!_characterStore.CharacterCollection.Any(c => c.Id == acDto.Character.Id))
                        {
                            await Task.Delay(5);
                            _characterStore.Add(character);
                            await _appDatabase.SaveCharacterAsync(CharacterMapper.ToEntity(character));
                        }

                        if(!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuuDto.Id))
                        {
                            await Task.Delay(5);
                            seiyuu = SeiyuuFactory.Create(seiyuuDto);
                            _seiyuuStore.Add(seiyuu);
                            await _appDatabase.SaveSeiyuuAsync(SeiyuuMapper.ToEntity(seiyuu));
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
            } else
            {
                _animeStore.Update(anime);
            }
            await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(anime));
        }

        public List<Anime> GetAllAnime()
        {
            throw new System.NotImplementedException();
        }
    }
}
