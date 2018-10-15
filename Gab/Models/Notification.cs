using Newtonsoft.Json;

namespace Gab.Models
{
    public class Notification
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }

        [JsonProperty("actuser")]
        public ActUser ActUser { get; set; }
    }
}