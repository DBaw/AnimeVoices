using AnimeVoices.DTO;
using Avalonia.Controls;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> AnimeList { get; set; }
        public int Seiyuu { get; set; }
        public Uri Image { get; set; }

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
            Image = !string.IsNullOrEmpty(characterDto.ImageUrl)
            ? new Uri(characterDto.ImageUrl, UriKind.Absolute)
            : new Uri("avares://AnimeVoices/Assets/not-found-image.png");
        }
    }
}