using AnimeVoices.DataModels.DTOs;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public interface IAnimeApi
    {
        public Task<SingleAnimeDto> GetAnimeByIdAsync(int id);
    }
}
