using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class ImageSetDto
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("small_image_url")]
        public string SmallImageUrl { get; set; }

        [JsonProperty("large_image_url")]
        public string LargeImageUrl { get; set; }
    }
}
