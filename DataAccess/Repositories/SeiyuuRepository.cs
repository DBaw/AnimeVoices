using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Factories;
using AnimeVoices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Repositories
{
    public class SeiyuuRepository : ISeiyuuRepository
    {
        private readonly ISeiyuuApi _seiyuuApi;

        public SeiyuuRepository(ISeiyuuApi seiyuuApi)
        {
            _seiyuuApi = seiyuuApi;
        }

        public async Task<Seiyuu> GetSeiyuuByIdAsync(int id)
        {
            var seiyuuDto = await _seiyuuApi.GetSeiyuuByIdAsync(id);
            return SeiyuuFactory.Create(seiyuuDto);
        }

        public async Task<List<Seiyuu>> GetTopSeiyuuAsync(int page)
        {
            var seiyuuDtos = await _seiyuuApi.GetTopSeiyuuAsync(page);

            var seiyuuModels = new List<Seiyuu>();
            foreach (var seiyuuDto in seiyuuDtos)
            {
                seiyuuModels.Add(SeiyuuFactory.Create(seiyuuDto));
            }

            return seiyuuModels;
        }
    }
}
