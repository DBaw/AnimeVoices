using Avalonia.Controls;
using System;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Seiyuu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Characters { get; set; }
        public Uri Image { get; set; }

        public Seiyuu(int id, List<int> characters) 
        {
            Id = id;
            Characters = characters;
        }
    }
}
