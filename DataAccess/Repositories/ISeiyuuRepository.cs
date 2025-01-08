using AnimeVoices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface ISeiyuuRepository
    {
        public Task InitializeAsync();
        public Task<Seiyuu> GetSeiyuuByIdAsync(int id);
        public Task<List<Seiyuu>> GetTopSeiyuuAsync(int page);
    }
}
