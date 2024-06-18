using System.Collections.Generic;

public class Anime
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Favourite { get; set; }
    public int Year { get; set; }
    public List<Character> Characters { get; set; }
    public Anime(int id, string title, List<Character> characters)
    {
        Id = id;
        Title = title;
        Characters = characters;
    }
}
