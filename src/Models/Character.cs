using AnimeVoices.Models;

public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Actor Actor { get; set; }

        public string Result { get; set; }

        public Character(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
