using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DTO
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FavouriteAnimes { get; set; }
        public string? FavouritesSeiyuus { get; set; }
        public string? Watchlist {  get; set; }

        public UserDto()
        {
            Name = string.Empty;
            Password = string.Empty;
            FavouriteAnimes = "[]";
            FavouritesSeiyuus = "[]";
            Watchlist = "[]";
        }
        public UserDto(string favouriteAnimes, string watchlist)
        {
            Name = string.Empty;
            Password = string.Empty;
            FavouriteAnimes = favouriteAnimes;
            FavouritesSeiyuus = "[]";
            Watchlist = watchlist;
        }
    }
}
