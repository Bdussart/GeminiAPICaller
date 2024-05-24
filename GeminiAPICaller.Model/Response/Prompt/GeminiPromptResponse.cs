using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPICaller.Model.Response.Prompt
{
    public class GeminiPromptResponse
    {
        [JsonProperty("candidates")]
        public List<Candidate> Candidates { get; set; }

        [JsonProperty("usageMetadata")]
        public UsageMetadata UsageMetadata { get; set; }

    }
}
