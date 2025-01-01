using Avalonia.Media.Imaging;

namespace AnimeVoices.Models
{
    public class Result
    {
        public string Anime {  get; set; }
        public string Character { get; set; }
        public Bitmap Image { get; set; }   

        public Result(string anime, string character, Bitmap image)
        {
            Anime = anime;
            Character = character;
            Image = image;
        }
    }
}
