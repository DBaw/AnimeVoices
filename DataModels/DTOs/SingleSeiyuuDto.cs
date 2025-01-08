using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs
{
    public class SingleSeiyuuDto
    {
        [JsonProperty("data")]
        public SeiyuuDto SeiyuuDto { get; set; }
    }
}
