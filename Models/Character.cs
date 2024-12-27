using Avalonia.Controls;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Seiyuus { get; set; }
        public Image ImageUrl { get; set; }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}