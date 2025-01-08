using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class VoiceDto
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("anime")]
        public AnimeDto Anime { get; set; }

        [JsonProperty("character")]
        public CharacterDto Character { get; set; }
    }
}
