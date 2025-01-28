using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public class JikanAnimeApi : IAnimeApi
    {
        private readonly HttpClient _httpClient;

        public JikanAnimeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SingleAnimeDto> GetAnimeByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("anime/" + id.ToString() + "/full");
            return JsonConvert.DeserializeObject<SingleAnimeDto>(response);
        }

        public async Task<TopAnimeDto> GetTopAnimeAsync(AnimePagination pagination)
        {
            var response = await _httpClient.GetStringAsync("top/anime?page=" + pagination.Page.ToString() + "&type=tv" + pagination.Properties);
            return JsonConvert.DeserializeObject<TopAnimeDto>(response);
        }

        public async Task<AnimeCharactersResponseDto> GetAnimeCharactersAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("anime/" + id.ToString() + "/characters");
            return JsonConvert.DeserializeObject<AnimeCharactersResponseDto> (response);
        }

    }
}
