using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class VoiceActorDto
    {
        [JsonProperty("person")]
        public SeiyuuDto SeiyuuDto { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        public VoiceActorDto()
        {
            
        }
    }
}
