using AnimeVoices.Utilities.Helpers;
using Avalonia.Media.Imaging;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Seiyuu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Characters { get; set; }
        public string ImageUrl { get; set; }

        public Seiyuu()
        {
            
        }

        public Seiyuu(int id, List<int> characters) 
        {
            Name = "Some Seiyuu";
            Id = id;
            Characters = characters;
            ImageUrl = "";
        }
    }
}
