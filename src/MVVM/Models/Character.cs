public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Favorites { get; set; }
    public string Image { get; set; }
    public Actor Actor { get; set; }
    public string Result { get; set; }
    public Character(string name)
    {
        Name = name;
    }
}
