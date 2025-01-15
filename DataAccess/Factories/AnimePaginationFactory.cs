using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.Models;

namespace AnimeVoices.DataAccess.Factories
{
    public static class AnimePaginationFactory
    {
        public static AnimePagination Create(PaginationDto dto, string properties)
        {
            return new AnimePagination
            {
                Page = dto.CurrentPage,
                HasNextPage = dto.HasNextPage,
                Properties = properties
            };
        }
    }
}
