using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PaginationDto
    {
        [JsonProperty("last_visible_page")]
        public int LastVisiblePage { get; set; }

        [JsonProperty("has_next_page")]
        public bool HasNextPage { get; set; }

        [JsonProperty("items")]
        public PaginationItemsDto Items { get; set; }
    }
}
