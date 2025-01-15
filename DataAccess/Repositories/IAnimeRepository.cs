using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface IAnimeRepository
    {
        Task InitializeAsync();
        Task GetTopAnimeAsync(int page);
        Task GetAnimeCharactersAsync(AnimeDto dto);
        Task<Anime> GetAnimeByIdAsync(int id);
    }
}
