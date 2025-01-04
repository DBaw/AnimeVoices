using AnimeVoices.DataModels.DTOs;
using AnimeVoices.Utilities.Helpers;
using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> AnimeList { get; set; }
        public int Seiyuu { get; set; }
        public Bitmap Image { get; set; }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
            Seiyuu = -1;
            AnimeList = new();
        }
        public Character(int id, string name, int seiyuu)
        {
            Id = id;
            Name = name;
            Seiyuu = seiyuu;
            AnimeList = new() ;
        }

        public Character(CharacterDto characterDto)
        {
            Id = characterDto.Id;
            Name = characterDto.Name;
            Seiyuu = characterDto.Seiyuu;
            AnimeList = string.IsNullOrEmpty(characterDto.AnimeJson) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(characterDto.AnimeJson);
            Image = string.IsNullOrEmpty(characterDto.ImageUrl) ? ImageHelper.LoadFromResource("avares://AnimeVoices/Assets/not-found-image.png") : ImageHelper.LoadFromWeb(characterDto.ImageUrl).Result;
        }
    }
}