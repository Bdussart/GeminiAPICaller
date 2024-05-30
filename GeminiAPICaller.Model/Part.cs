using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeminiAPICaller.Model
{
    public class Part
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        public override string ToString()
        {
            return $"Text : {Text}";
        }
    }
}
