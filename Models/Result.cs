namespace AnimeVoices.Models
{
    public class Result
    {
        public string Anime {  get; set; }
        public string Character { get; set; }

        public Result(string anime, string character)
        {
            Anime = anime;
            Character = character;
        }
    }
}
