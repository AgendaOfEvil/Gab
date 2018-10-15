using Newtonsoft.Json;

namespace Gab.Models
{
    public class CategoryDetails
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("emoji")]
        public string Emoji { get; set; }
    }
}