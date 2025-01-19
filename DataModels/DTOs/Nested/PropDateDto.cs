using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PropDateDto
    {
        [JsonProperty("from")]
        public SimpleDateDto From { get; set; }

        [JsonProperty("to")]
        public SimpleDateDto To { get; set; }
    }
}
