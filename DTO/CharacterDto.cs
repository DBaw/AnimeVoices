using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class CharacterDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string AnimeJson {  get; set; }
        public int Seiyuu { get; set; }
        public string ImageUrl { get; set; }

        public CharacterDto()
        {
            
        }

        public CharacterDto(int id, string name, string anime, int seiyuu)
        {
            Id = id;
            Name = name;
            AnimeJson = String.IsNullOrEmpty(anime) ? String.Empty : anime;
            Seiyuu = seiyuu;
            ImageUrl = "";
        }
    }
}
