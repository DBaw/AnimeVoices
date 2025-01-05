using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class StudioOrProducerDto
    {
        [JsonProperty("mal_id")]
        public int MalId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
