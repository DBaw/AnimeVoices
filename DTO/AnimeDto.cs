using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class AnimeDto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public double Score { get; set; }
    }
}
