using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public interface ISeiyuuApi
    {
        public Task<SingleSeiyuuDto> GetSeiyuuByIdAsync(int id);
        public Task<TopSeiyuuDto> GetTopSeiyuuAsync(int page);
    }
}
