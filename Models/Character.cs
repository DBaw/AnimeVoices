using Avalonia.Controls;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seiyuu { get; set; }
        public Image ImageUrl { get; set; }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Character(int id, string name, int seiyuu)
        {
            Id = id;
            Name = name;
            Seiyuu = seiyuu;
        }
    }
}