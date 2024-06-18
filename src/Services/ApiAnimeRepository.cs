using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeVoices.Services
{
    public class ApiAnimeRepository : IAnimeRepository
    {
        private readonly HttpClient _httpClient;

        public ApiAnimeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ObservableCollection<Anime>> GetAnimesAsync()
        {
            var response = await _httpClient.GetStringAsync("api/anime");
            return JsonConvert.DeserializeObject<ObservableCollection<Anime>>(response);
        }
    }
}
