using System;
using System.Collections.Generic;
using Gab.Converters;
using Newtonsoft.Json;

namespace Gab.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pinned_post_id")]
        public string PinnedPostId { get; set; }

        [JsonProperty("archived_at")]
        public object ArchivedAt { get; set; }

        [JsonProperty("cover_url")]
        public string CoverUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_joined")]
        public bool IsJoined { get; set; }

        [JsonProperty("users")]
        [JsonConverter(typeof(GroupUsersConverter))]
        public List<ActUser> Users { get; set; }
    }
}