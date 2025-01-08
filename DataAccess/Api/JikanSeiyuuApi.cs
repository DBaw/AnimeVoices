using AnimeVoices.DataModels.DTOs;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.DataAccess.Api
{
    public class JikanSeiyuuApi : ISeiyuuApi
    {
        private readonly HttpClient _httpClient;

        public JikanSeiyuuApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SingleSeiyuuDto> GetSeiyuuByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("people/" + id.ToString() + "/full");
            return JsonConvert.DeserializeObject<SingleSeiyuuDto>(response);
        }

        public async Task<TopSeiyuuDto> GetTopSeiyuuAsync(int page)
        {
            var response = await _httpClient.GetStringAsync("top/people?page=" + page.ToString());
            return JsonConvert.DeserializeObject<TopSeiyuuDto>(response);
        }
    }
}
