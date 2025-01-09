using Avalonia.Media.Imaging;

namespace AnimeVoices.Models
{
    public class Result
    {
        public string Anime {  get; set; }
        public string Character { get; set; }
        public string ImageUrl { get; set; }   

        public Result(string anime, string character, string image)
        {
            Anime = anime;
            Character = character;
            ImageUrl = image;
        }
    }
}
