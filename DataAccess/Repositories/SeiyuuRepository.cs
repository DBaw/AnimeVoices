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
using System.IO;
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
        private readonly AnimeStore _animeStore;
        private readonly CharacterStore _characterStore;

        public SeiyuuRepository(ISeiyuuApi seiyuuApi, IAppDatabase appDatabase, SeiyuuStore seiyuuStore, SeiyuuDtoStore seiyuuDtoStore, AnimeStore animeStore, CharacterStore characterStore)
        {
            _seiyuuApi = seiyuuApi;
            _appDatabase = appDatabase;
            _seiyuuStore = seiyuuStore;
            _seiyuuDtoStore = seiyuuDtoStore;
            _animeStore = animeStore;
            _characterStore = characterStore;
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

            //_seiyuuDtoStore.Add(seiyuuDto);

            var seiyuu = SeiyuuFactory.Create(seiyuuDto);

            if (!_seiyuuStore.SeiyuuCollection.Any(s => s.Id == seiyuu.Id))
            {
                _seiyuuStore.Add(seiyuu);
                //await _appDatabase.SaveSeiyuuAsync(SeiyuuMapper.ToEntity(seiyuu));
            }

            await ParseSeiyuuData(seiyuuDto);
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

        public async Task ParseSeiyuuData(SeiyuuDto dto)
        {
            // Map of CharacterId to their associated VoiceDto entries
            Dictionary<int, List<VoiceDto>> characterVoices = new();

            // Populate the map
            foreach (VoiceDto vd in dto.Voices)
            {
                if (!characterVoices.TryGetValue(vd.Character.Id, out var voiceList))
                {
                    voiceList = new List<VoiceDto>();
                    characterVoices[vd.Character.Id] = voiceList;
                }
                voiceList.Add(vd);
            }

            // Process each CharacterId
            foreach (var (characterId, voices) in characterVoices)
            {
                // Find the VoiceDto with the shortest anime title
                VoiceDto shortestTitleVoice = voices.OrderBy(v => v.Anime.Title.Length).First();

                // Create or update Character
                Character? existingCharacter = _characterStore.CharacterCollection.FirstOrDefault(c => c.Id == characterId);
                Character updatedCharacter = new Character
                {
                    Id = characterId,
                    Name = shortestTitleVoice.Character.Name,
                    AnimeId = shortestTitleVoice.Anime.Id,
                    Seiyuu = dto.Id,
                    ImageUrl = shortestTitleVoice.Character.Images?.Jpg.ImageUrl
                };

                if (existingCharacter != null)
                {
                    if (existingCharacter.AnimeId != updatedCharacter.AnimeId)
                    {
                        _characterStore.Update(updatedCharacter);
                        //await _appDatabase.SaveCharacterAsync(CharacterMapper.ToEntity(updatedCharacter));
                    }
                }
                else
                {
                    _characterStore.Add(updatedCharacter);
                    //await _appDatabase.SaveCharacterAsync(CharacterMapper.ToEntity(updatedCharacter));
                }

                // Check for anime ID in aliases
                Anime? matchedAnime = _animeStore.AnimeCollection.FirstOrDefault(
                    a => a.Id == shortestTitleVoice.Anime.Id || a.Aliases.Contains(shortestTitleVoice.Anime.Id)
                );

                if (matchedAnime == null)
                {
                    // Add new anime
                    Anime newAnime = new Anime
                    {
                        Id = shortestTitleVoice.Anime.Id,
                        Title = shortestTitleVoice.Anime.Title,
                        Characters = new List<int> { characterId }
                    };
                    _animeStore.Add(newAnime);
                    //await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(newAnime));
                }
                else
                {
                    // Update existing anime
                    if (!matchedAnime.Characters.Contains(characterId))
                    {
                        matchedAnime.Characters.Add(characterId);
                        _animeStore.Update(matchedAnime);
                        //await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(matchedAnime));
                    }

                    // Update aliases to include the new anime ID if needed
                    if (!matchedAnime.Aliases.Contains(shortestTitleVoice.Anime.Id))
                    {
                        matchedAnime.Aliases.Add(shortestTitleVoice.Anime.Id);
                        _animeStore.Update(matchedAnime);
                        //await _appDatabase.SaveAnimeAsync(AnimeMapper.ToEntity(matchedAnime));
                    }
                }
            }
        }

    }
}
