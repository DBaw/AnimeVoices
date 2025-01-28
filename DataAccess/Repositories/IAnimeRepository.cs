using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface IAnimeRepository
    {
        Task InitializeAsync();
        Task GetTopAnimeAsync(string properties);
        Task GetAnimeCharactersAsync(AnimeDto dto);
        Task<Anime> GetAnimeByIdAsync(int id);
        Task RefreshTopAnimeAsync(string properties, int page);
    }
}
