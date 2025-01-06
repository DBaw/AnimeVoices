using AnimeVoices.DataModels.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public class JikanAnimeApi
    {
        private readonly HttpClient _httpClient;

        public JikanAnimeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AnimeDto> GetAnimeByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("anime/" + id.ToString() + "/full");
            return JsonConvert.DeserializeObject<AnimeDto>(response);
        }
    }
}
