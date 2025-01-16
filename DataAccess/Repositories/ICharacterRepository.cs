using AnimeVoices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface ICharacterRepository
    {
        public Task InitializeAsync();
    }
}
