using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.Entities;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Repositories
{
    public interface IAnimeRepository
    {
        public List<Anime> GetAnimeFromSeiyuu(SeiyuuDto dto);
        public List<Anime> GetAllAnime(List<AnimeEntity> entities);
    }
}
