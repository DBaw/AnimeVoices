using Newtonsoft.Json;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class ImagesDto
    {
        [JsonProperty("jpg")]
        public ImageSetDto Jpg { get; set; }

        [JsonProperty("webp")]
        public ImageSetDto Webp { get; set; }
    }
}
