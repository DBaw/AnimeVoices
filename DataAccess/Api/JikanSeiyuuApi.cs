﻿using AnimeVoices.DataModels.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public async Task<SeiyuuDto> GetSeiyuuByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync("people/" + id.ToString() + "/full");
            return JsonConvert.DeserializeObject<SeiyuuDto>(response);
        }

        public async Task<List<SeiyuuDto>> GetTopSeiyuuAsync(int page)
        {
            var response = await _httpClient.GetStringAsync("top/people?page=" + page.ToString());
            return JsonConvert.DeserializeObject<List<SeiyuuDto>>(response);
        }
    }
}
