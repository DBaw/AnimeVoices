﻿using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class SeiyuuDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CharactersJson { get; set; }
        public string ImageUrl { get; set; }

        public SeiyuuDto()
        {
            
        }
    }
}
