using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
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
                Seiyuu = model.Seiyuu,
                ImageUrl = model.ImageUrl
            };
        }
    }
}
