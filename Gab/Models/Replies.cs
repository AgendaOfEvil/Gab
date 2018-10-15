using Newtonsoft.Json;

namespace Gab.Models
{
    public class Replies
    {
        [JsonProperty("data")]
        public object[] Data { get; set; }
    }
}