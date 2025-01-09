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
    }
}
