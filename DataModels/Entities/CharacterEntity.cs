using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.Entities
{
    public class CharacterEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int AnimeId { get; set; }
        public int Seiyuu { get; set; }
        public string ImageUrl { get; set; }

        public CharacterEntity()
        {
            
        }
    }
}
