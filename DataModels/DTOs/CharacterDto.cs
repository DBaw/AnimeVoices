using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.DTOs
{
    public class CharacterDto
    {
        [Key]
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("images")]
        public ImagesDto Images { get; set; }

        [JsonProperty("voices")]
        public List<VoiceDto> Voices { get; set; }

        public CharacterDto()
        {

        }
    }
}
