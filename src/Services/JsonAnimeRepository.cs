using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace AnimeVoices.Services
{
    public class JsonAnimeRepository : IAnimeRepository
    {
        private readonly string _filePath;

        public JsonAnimeRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<ObservableCollection<Anime>> GetAnimesAsync()
        {
            using (var reader = new StreamReader(_filePath))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Anime>>(json);
            }
        }
    }
}
