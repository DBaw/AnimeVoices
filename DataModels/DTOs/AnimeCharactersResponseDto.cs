using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.DataModels.DTOs
{
    public class AnimeCharactersResponseDto
    {
        [JsonProperty("data")]
        public List<AnimeCharactersDto> AnimeCharacters { get; set; }
    }
}
