using AnimeVoices.DTO;
using Avalonia.Controls;
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
        public Image ImageUrl { get; set; }

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
            AnimeList = string.IsNullOrEmpty(characterDto.AnimeJson) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(characterDto.AnimeJson); ;
        }
    }
}