using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class AiredDto
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("prop")]
        public PropDateDto Prop { get; set; }
    }
}
