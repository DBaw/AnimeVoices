using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PaginationItemsDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}
