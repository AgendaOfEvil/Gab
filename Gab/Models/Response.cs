using Newtonsoft.Json;

namespace Gab.Models
{
    public class Response<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("no-more")]
        public bool NoMore { get; set; }
    }
}