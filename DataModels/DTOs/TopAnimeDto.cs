using AnimeVoices.DataModels.DTOs.Nested;
using System.Collections.Generic;

namespace AnimeVoices.DataModels.DTOs
{
    public class TopAnimeDto
    {
        public List<AnimeDto> Data { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
