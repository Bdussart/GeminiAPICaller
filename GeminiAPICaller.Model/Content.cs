using Microsoft.VisualBasic;
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

        public override string ToString()
        {
            string partsInfo = Parts != null && Parts.Any() ? string.Join('|', Parts) : String.Empty;
            return $"Role : {Role}, Parts : {partsInfo}";
        }

    }
}
