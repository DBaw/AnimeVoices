using AnimeVoices.DataModels.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public interface ISeiyuuApi
    {
        public Task<SeiyuuDto> GetSeiyuuByIdAsync(int id);
        public Task<List<SeiyuuDto>> GetTopSeiyuuAsync(int page);
    }
}
