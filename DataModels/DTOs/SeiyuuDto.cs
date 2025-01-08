using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.DataModels.DTOs
{
    public class SeiyuuDto
    {
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("images")]
        public ImagesDto Images { get; set; }

        [JsonProperty("voices")]
        public List<VoiceDto> Voices { get; set; }

        public SeiyuuDto() { }
    }
}
