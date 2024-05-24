using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPICaller.Model.Response.Prompt
{
    public class UsageMetadata
    {
        [JsonProperty("promptTokenCount")]
        public int PromptTokenCount { get; set; }

        [JsonProperty("candidatesTokenCount")]
        public int CandidatesTokenCount { get; set; }

        [JsonProperty("totalTokenCount")]
        public int TotalTokenCount { get; set; }
    }
}
