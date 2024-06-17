using System.Collections.Generic;

public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Character> Characters { get; set; }
        public Anime(int id, string title)
        {
            Id = id;
            Title = title;
            Characters = new List<Character>();
        }
}
