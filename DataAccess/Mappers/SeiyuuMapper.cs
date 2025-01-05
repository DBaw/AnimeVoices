using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Linq;

namespace AnimeVoices.DataAccess.Mappers
{
    public static class SeiyuuMapper
    {
        public static Seiyuu ToModel(SeiyuuEntity entity)
        {
            return new Seiyuu
            {
                Id = entity.Id,
                Name = entity.Name,
                Characters = entity.Characters.Split(",").ToList().Select(int.Parse).ToList(),
                ImageUrl = entity.ImageUrl,
            };
        }

        public static SeiyuuEntity ToEntity(Seiyuu model)
        {
            return new SeiyuuEntity
            {
                Id = model.Id,
                Name = model.Name,
                Characters = string.Join(",", model.Characters),
                ImageUrl = model.ImageUrl,
            };
        }
    }
}
