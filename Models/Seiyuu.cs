using Avalonia.Controls;
using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Seiyuu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Characters { get; set; }
        public Image Picture { get; set; }
    }
}
