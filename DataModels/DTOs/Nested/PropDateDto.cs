using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeVoices.DataModels.DTOs.Nested
{
    public class PropDateDto
    {
        [JsonProperty("from")]
        public SimpleDateDto From { get; set; }

        [JsonProperty("to")]
        public SimpleDateDto To { get; set; }

        [JsonProperty("string")]
        public string Period { get; set; }
    }
}
