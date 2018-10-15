using Newtonsoft.Json;

namespace Gab.WPF
{
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at_month_label")]
        public string CreatedAtMonthLabel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("post_count")]
        public int PostCount { get; set; }

        [JsonProperty("picture_url")]
        public string PictureUrl { get; set; }

        [JsonProperty("picture_url_full")]
        public string PictureUrlFull { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("followed")]
        public bool Followed { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("is_pro")]
        public bool IsPro { get; set; }

        [JsonProperty("is_donor")]
        public bool IsDonor { get; set; }

        [JsonProperty("is_investor")]
        public bool IsInvestor { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [JsonProperty("is_tippable")]
        public bool IsTippable { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_accessible")]
        public bool IsAccessible { get; set; }

        [JsonProperty("follow_pending")]
        public bool FollowPending { get; set; }
    }
}