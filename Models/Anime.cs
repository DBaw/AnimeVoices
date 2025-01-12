using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        /*
        public string Rating { get; set; }
        public string Score { get; set; }
        public string Studio { get; set; }
        public string Aired { get; set; }
        public string Status { get; set; }
        public string Synopsis { get; set; }
        public string Episodes { get; set; }
        */
        public List<int> Characters { get; set; } = new List<int>();
        public List<int> Aliases { get; set; } = new List<int>();
        public bool IsFavourite { get; set; }
        public bool IsOnWatchlist { get; set; }

        public Anime()
        {
            
        }
    }
}
