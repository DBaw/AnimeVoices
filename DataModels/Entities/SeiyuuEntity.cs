using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.Entities
{
    public class SeiyuuEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Characters { get; set; } // Id's separated by comma
        public string ImageUrl { get; set; }
    }
}
