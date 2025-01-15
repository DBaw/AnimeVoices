using AnimeVoices.DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeVoices.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnimeEntity> Anime { get; set; }
        public DbSet<CharacterEntity> Character { get; set; }
        public DbSet<SeiyuuEntity> Seiyuu { get; set; }
        public DbSet<AnimePaginationEntity> AnimePagination { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
