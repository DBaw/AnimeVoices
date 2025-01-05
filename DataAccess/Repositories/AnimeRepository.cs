using AnimeVoices.DataAccess.Factories;
using AnimeVoices.DataAccess.Mappers;
using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        public List<Anime> GetAllAnime(List<AnimeEntity> entities)
        {
            List<Anime> result = new();
            
            foreach (AnimeEntity entity in entities)
            {
                Anime anime = AnimeMapper.ToModel(entity);
                result.Add(anime);
            }

            return result;
        }

        public List<Anime> GetAnimeFromSeiyuu(SeiyuuDto dto)
        {
            return AnimeFactory.Create(dto);
        }
    }
}
