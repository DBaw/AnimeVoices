using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class CharacterDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Seiyuu { get; set; }
        public string ImageUrl { get; set; }

        public CharacterDto()
        {
            
        }
    }
}
