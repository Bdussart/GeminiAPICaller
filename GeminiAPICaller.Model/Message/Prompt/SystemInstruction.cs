using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeminiAPICaller.Model.Message.Prompt
{
    public class SystemInstruction
    {
        [JsonProperty("role")]
        public string Role { get; set; } = "system";

        [JsonProperty("parts")]
        public List<Part> Parts { get; set; }

    }
}
