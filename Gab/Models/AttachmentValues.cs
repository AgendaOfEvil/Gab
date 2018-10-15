using Newtonsoft.Json;

namespace Gab.Models
{
    public class YouTubeAttachment
    {
        public string Id { get; set; }
    }

    public class GiphyAttachment
    {
        public string Id { get; set; }
    }

    public class UrlAttachment
    {
        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class MediaAttachment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url_thumbnail")]
        public string UrlThumbnail { get; set; }

        [JsonProperty("url_full")]
        public string UrlFull { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }
}