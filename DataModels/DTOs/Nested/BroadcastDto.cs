using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class BroadcastDto
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("string")]
        public string FullTime { get; set; }
    }
}
