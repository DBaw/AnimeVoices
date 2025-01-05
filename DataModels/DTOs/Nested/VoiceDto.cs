using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class VoiceDto
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("person")]
        public SeiyuuDto Seiyuu { get; set; }
    }
}
