using AnimeVoices.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimeVoices.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnimeEntity> Anime { get; set; }
        public DbSet<CharacterEntity> Character { get; set; }
        public DbSet<SeiyuuEntity> Seiyuu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = System.IO.Path.Combine(AppContext.BaseDirectory, "AnimeVoices.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
