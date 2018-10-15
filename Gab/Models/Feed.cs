using Newtonsoft.Json;

namespace Gab.Models
{
    public class Feed
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("published_at")]
        public string PublishedAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("actuser")]
        public ActUser ActUser { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }
    }
}