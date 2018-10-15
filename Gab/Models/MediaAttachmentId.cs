using Newtonsoft.Json;

namespace Gab.Models
{
    public class MediaAttachmentId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}