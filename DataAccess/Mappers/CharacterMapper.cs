using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Linq;

namespace AnimeVoices.DataAccess.Mappers
{
    public static class CharacterMapper
    {
        public static Character ToModel(CharacterEntity entity)
        {
            return new Character
            {
                Id = entity.Id,
                Name = entity.Name,
                AnimeId = entity.AnimeId,
                Seiyuu = entity.Seiyuu,
                ImageUrl = entity.ImageUrl
            };
        }

        public static CharacterEntity ToEntity(Character model)
        {
            return new CharacterEntity
            {
                Id = model.Id,
                Name = model.Name,
                AnimeId = model.AnimeId,
                Seiyuu = model.Seiyuu,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
