using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PaginationDto
    {
        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("items")]
        public PaginationItemsDto Items { get; set; }
    }
}
