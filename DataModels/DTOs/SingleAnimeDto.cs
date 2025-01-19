using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs
{
    public class SingleAnimeDto
    {
        [JsonProperty("data")]
        public AnimeDto AnimeDto { get; set; }
    }
}
