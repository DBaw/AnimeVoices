public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    public Actor(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
