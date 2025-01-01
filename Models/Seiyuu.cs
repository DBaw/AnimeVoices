using AnimeVoices.DTO;
using AnimeVoices.Utilities.Helpers;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Seiyuu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Characters { get; set; }
        public Bitmap Image { get; set; }

        public Seiyuu(int id, List<int> characters) 
        {
            Name = "Some Seiyuu";
            Id = id;
            Characters = characters;
            Image = string.IsNullOrEmpty("") ? ImageHelper.LoadFromResource("avares://AnimeVoices/Assets/not-found-image.png") : ImageHelper.LoadFromWeb("").Result;
        }
    }
}
