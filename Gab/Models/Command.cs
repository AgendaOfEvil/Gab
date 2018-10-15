using Newtonsoft.Json;

namespace Gab.Models
{
    public class Command
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}