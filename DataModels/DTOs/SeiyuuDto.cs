using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.DTOs
{
    public class SeiyuuDto
    {
        [Key]
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("mal_id")]
        public ImagesDto Images { get; set; }

        [JsonProperty("voices")]
        public List<VoiceDto> Voices { get; set; }

        public SeiyuuDto()
        {

        }
    }
}
