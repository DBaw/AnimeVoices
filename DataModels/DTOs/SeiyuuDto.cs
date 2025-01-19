using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs
{
    public class SeiyuuDto
    {
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public ImagesDto Images { get; set; }

        public SeiyuuDto() { }
    }
}
