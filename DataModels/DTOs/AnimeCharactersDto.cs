using AnimeVoices.DataModels.DTOs.Nested;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimeVoices.DataModels.DTOs
{
    public class AnimeCharactersDto
    {
        [JsonProperty("character")]
        public CharacterDto Character { get; set; }

        [JsonProperty("favorites")]
        public int Favorites { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("voice_actors")]
        public List<VoiceActorDto> SeiyuuList { get; set; }

        public AnimeCharactersDto()
        {
            
        }
    }
}
