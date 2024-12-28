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
        public List<int> Anime { get; set; }
        public int Seiyuu { get; set; }
        public Image ImageUrl { get; set; }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
            Seiyuu = -1;
            Anime = new();
        }
        public Character(int id, string name, int seiyuu)
        {
            Id = id;
            Name = name;
            Seiyuu = seiyuu;
            Anime = new() ;
        }

        public Character(CharacterDto characterDto)
        {
            Id = characterDto.Id;
            Name = characterDto.Name;
            Seiyuu = characterDto.Seiyuu;
            Anime = string.IsNullOrEmpty(characterDto.Anime) ? new List<int>() : JsonConvert.DeserializeObject<List<int>>(characterDto.Anime); ;
        }
    }
}