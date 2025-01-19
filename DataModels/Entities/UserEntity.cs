using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FavouriteAnimes { get; set; }
        public string? FavouritesSeiyuus { get; set; }
        public string? Watchlist { get; set; }
    }
}
