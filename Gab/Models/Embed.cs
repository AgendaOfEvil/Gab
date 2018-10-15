using Newtonsoft.Json;

namespace Gab.Models
{
    public class Embed
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("iframe")]
        public bool Iframe { get; set; }
    }
}