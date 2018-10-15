using Newtonsoft.Json;

namespace Gab.Models
{
    public class ActUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("picture_url")]
        public string PictureUrl { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("is_donor")]
        public bool IsDonor { get; set; }

        [JsonProperty("is_investor")]
        public bool IsInvestor { get; set; }

        [JsonProperty("is_pro")]
        public bool IsPro { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }
    }
}