using AnimeVoices.DataModels.DTOs;
using AnimeVoices.DataModels.DTOs.Nested;
using AnimeVoices.Models;
using System.Collections.Generic;

namespace AnimeVoices.DataAccess.Factories
{
    public static class AnimeFactory
    {
        public static List<Anime> Create(SeiyuuDto dto)
        {
            List<Anime> animeList = new();
            Dictionary<int, Anime> animeDictionary = new();

            foreach (VoiceDto vd in dto.Voices)
            {
                if (!animeDictionary.TryGetValue(vd.Anime.Id, out Anime existingAnime))
                {
                    existingAnime = new Anime()
                    {
                        Id = vd.Anime.Id,
                        Title = vd.Anime.Title,
                        Characters = new List<int>(),
                        IsFavourite = false,
                        IsOnWatchlist = false,
                    };

                    animeDictionary[vd.Anime.Id] = existingAnime;
                    animeList.Add(existingAnime);
                }

                if (!existingAnime.Characters.Contains(vd.Character.Id))
                {
                    existingAnime.Characters.Add(vd.Character.Id);
                }
            }

            return animeList;
        }
    }
}
