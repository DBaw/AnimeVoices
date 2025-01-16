using AnimeVoices.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace AnimeVoices.DB
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            string dbPath = Path.Combine(AppContext.BaseDirectory, AppSettings.UsersDbFileName);

            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}
