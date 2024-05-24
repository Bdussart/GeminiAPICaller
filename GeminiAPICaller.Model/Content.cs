using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace GeminiAPICaller.Model
{
    public class Content
    {
        [JsonProperty("role")]
        public string Role { get; set; } = "user";
        [JsonProperty("parts")]
        public List<Part> Parts { get; set; }

    }
}
