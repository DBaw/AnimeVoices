using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;

namespace AnimeVoices.DataAccess.Mappers
{
    public static class AnimePaginationMapper
    {
        public static AnimePagination ToModel(AnimePaginationEntity entity)
        {
            return new AnimePagination
            {
                Properties = entity.Properties,
                HasNextPage = entity.HasNextPage,
                Page = entity.Page,
            };
        }

        public static AnimePaginationEntity ToEntity(AnimePagination model)
        {
            return new AnimePaginationEntity
            {
                Properties = model.Properties,
                HasNextPage = model.HasNextPage,
                Page = model.Page,
            };
        }
    }
}
