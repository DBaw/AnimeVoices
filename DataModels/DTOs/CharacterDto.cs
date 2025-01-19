using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.DTOs
{
    public class CharacterDto
    {
        [Key]
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public ImagesDto Images { get; set; }

        public CharacterDto()
        {

        }
    }
}
