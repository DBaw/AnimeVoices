using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimeId { get; set; }
        public int Seiyuu { get; set; }
        public string ImageUrl { get; set; }

        public Character()
        {
            
        }
    }
}