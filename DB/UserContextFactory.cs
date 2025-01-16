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
            string usersDbFileName = "Users.db";
            string dbPath = Path.Combine(AppContext.BaseDirectory, usersDbFileName);

            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}
