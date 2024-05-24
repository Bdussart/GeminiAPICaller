using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeminiAPICaller.Model.Message.Prompt
{
    public class GeminiPromptMessage
    {
        [JsonProperty("contents")]
        public List<Content> Contents { get; set; }

        [JsonProperty("systemInstruction")]
        public SystemInstruction SystemInstruction { get; set; }
    }
}
