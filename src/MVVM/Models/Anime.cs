using System.Collections.Generic;

public class Anime
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Favourite { get; set; }
    public int Year { get; set; }
    public List<Character> Characters { get; set; }
    public Anime(string title)
    {
        Title = title;
    }
}
