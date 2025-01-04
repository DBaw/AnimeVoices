using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string? FavouriteAnimesJson { get; set; }
        public string? FavouritesSeiyuusJson { get; set; }
        public string? Watchlist {  get; set; }

        public UserDto()
        {
            Name = string.Empty;
            Password = string.Empty;
            FavouriteAnimesJson = "[]";
            FavouritesSeiyuusJson = "[]";
            Watchlist = "[]";
        }
        public UserDto(string favouriteAnimes, string watchlist)
        {
            Name = string.Empty;
            Password = string.Empty;
            FavouriteAnimesJson = favouriteAnimes;
            FavouritesSeiyuusJson = "[]";
            Watchlist = watchlist;
        }
    }
}
