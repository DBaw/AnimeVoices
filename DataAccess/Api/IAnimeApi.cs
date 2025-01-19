using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public interface IAnimeApi
    {
        public Task<TopAnimeDto> GetTopAnimeAsync(AnimePagination pagination);
        public Task<AnimeCharactersResponseDto> GetAnimeCharactersAsync(int id);
        public Task<SingleAnimeDto> GetAnimeByIdAsync(int id);
    }
}
