using System.Collections.Generic;

namespace AnimeVoices.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EngTitle { get; set; }
        public string Rating { get; set; }
        public string Score { get; set; }
        public string Studio { get; set; }
        public string Aired { get; set; }
        public string Status { get; set; }
        public string About { get; set; }
        public string Episodes { get; set; }
        public List<int> Characters { get; set; }
        public string Broadcast { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsOnWatchlist { get; set; }

        public Anime()
        {
            
        }
    }
}
