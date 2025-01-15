using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimeVoices.DataModels.DTOs
{
    public class AnimeDto
    {
        [Key]
        [JsonProperty("mal_id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("images")]
        public ImagesDto Images { get; set; }
        
        [JsonProperty("episodes")]
        public int? Episodes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("airing")]
        public bool Airing { get; set; }

        [JsonProperty("aired")]
        public AiredDto Aired { get; set; }

        [JsonProperty("score")]
        public double? Score { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("synopsis")]
        public string About { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("broadcast")]
        public BroadcastDto Broadcast { get; set; }

        [JsonProperty("producers")]
        public List<StudioOrProducerDto> Producers { get; set; }

        [JsonProperty("studios")]
        public List<StudioOrProducerDto> Studios { get; set; }
        
        public AnimeDto()
        {

        }
    }
}
