using AnimeVoices.DataModels.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public interface IAnimeApi
    {
        public Task<TopAnimeDto> GetTopAnimeAsync(int page);
        public Task<AnimeCharactersResponseDto> GetAnimeCharactersAsync(int id);
        public Task<SingleAnimeDto> GetAnimeByIdAsync(int id);
    }
}
