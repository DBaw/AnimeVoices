﻿using AnimeVoices.DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeVoices.DB
{
    public interface IAppDatabase
    {
        Task<List<AnimeEntity>> GetAllAnimeAsync();
        Task SaveAnimeAsync(AnimeEntity anime);
        Task UpdateAnimeAsync(AnimeEntity anime);

        Task<List<CharacterEntity>> GetAllCharactersAsync();
        Task SaveCharacterAsync(CharacterEntity character);
        Task UpdateCharacterAsync(CharacterEntity character);

        Task<List<SeiyuuEntity>> GetAllSeiyuuAsync();
        Task SaveSeiyuuAsync(SeiyuuEntity seiyuu);
    }
}
