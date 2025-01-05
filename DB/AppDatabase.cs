using AnimeVoices.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DB
{
    public class AppDatabase : IAppDatabase
    {
        private readonly AppDbContext _dbContext;

        public AppDatabase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Anime Operations
        public async Task<List<AnimeEntity>> GetAllAnimeAsync()
        {
            return await _dbContext.Anime.ToListAsync();
        }

        public async Task SaveAnimeAsync(AnimeEntity anime)
        {
            var existingAnime = await _dbContext.Anime.FindAsync(anime.Id);
            if (existingAnime == null)
            {
                await _dbContext.Anime.AddAsync(anime);
            }
            else
            {
                _dbContext.Entry(existingAnime).CurrentValues.SetValues(anime);
            }
            await _dbContext.SaveChangesAsync();
        }

        // Character Operations
        public async Task<List<CharacterEntity>> GetAllCharactersAsync()
        {
            return await _dbContext.Character.ToListAsync();
        }

        public async Task SaveCharacterAsync(CharacterEntity character)
        {
            var existingCharacter = await _dbContext.Character.FindAsync(character.Id);
            if (existingCharacter == null)
            {
                await _dbContext.Character.AddAsync(character);
            }
            else
            {
                _dbContext.Entry(existingCharacter).CurrentValues.SetValues(character);
            }
            await _dbContext.SaveChangesAsync();
        }

        // Seiyuu Operations
        public async Task<List<SeiyuuEntity>> GetAllSeiyuuAsync()
        {
            return await _dbContext.Seiyuu.ToListAsync();
        }

        public async Task SaveSeiyuuAsync(SeiyuuEntity seiyuu)
        {
            var existingSeiyuu = await _dbContext.Seiyuu.FindAsync(seiyuu.Id);
            if (existingSeiyuu == null)
            {
                await _dbContext.Seiyuu.AddAsync(seiyuu);
            }
            else
            {
                _dbContext.Entry(existingSeiyuu).CurrentValues.SetValues(seiyuu);
            }
            await _dbContext.SaveChangesAsync();
        }
    }

}
