using AnimeVoices.DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeVoices.DB
{
    public class UserDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
    }
}
