using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class SimpleDateDto
    {
        [JsonProperty("day")]
        public int? Day { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }
    }
}
