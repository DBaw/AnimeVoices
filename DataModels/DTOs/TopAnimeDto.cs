using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.DataModels.DTOs
{
    public class TopAnimeDto
    {
        [JsonProperty("data")]
        public List<AnimeDto> AnimeDto { get; set; }

        [JsonProperty("pagination")]
        public PaginationDto PaginationDto { get; set; }

        public TopAnimeDto()
        {
            
        }
    }
}
