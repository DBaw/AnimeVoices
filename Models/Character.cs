using AnimeVoices.DTO;
using AnimeVoices.Utilities.Helpers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Material.Icons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

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
            /*
             * if (string.IsNullOrEmpty(characterDto.ImageUrl))
            {
                Image = new Bitmap(AssetLoader.Open(new Uri("avares://AnimeVoices/Assets/not-found-image.png")));
            }
            else
            {
                using var httpClient = new HttpClient();
                var response = httpClient.GetAsync(characterDto.ImageUrl);
                var data = response.Result.Content.ReadAsStream().ReadByte();
                Image =  new Bitmap(new MemoryStream(data));
            }
            */
        }
    }
}