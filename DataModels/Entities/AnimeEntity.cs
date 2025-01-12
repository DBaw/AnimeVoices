using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.Entities
{
    public class AnimeEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Rating { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public string Aired { get; set; }
        public string Status { get; set; }
        public string Synopsis { get; set; }
        public int Episodes { get; set; }
        public string Characters { get; set; } // ID's separate by comma
        public string Aliases { get; set; } // Aliases's separate by comma

        public AnimeEntity()
        {
            
        }
    }
}
