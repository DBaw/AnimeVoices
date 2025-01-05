using AnimeVoices.DataModels.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public class JikanAnimeApi
    {
        private HttpClient _httpClient;

        public JikanAnimeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("https://api.jikan.moe/v4/");
        }

        public async Task<AnimeDto> GetAnimeByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("anime/" + id.ToString() + "/full");
            return JsonConvert.DeserializeObject<AnimeDto>(response);
        }
    }
}
