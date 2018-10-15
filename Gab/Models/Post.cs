using System;
using Gab.Converters;
using Newtonsoft.Json;

namespace Gab.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("revised_at")]
        public DateTimeOffset? RevisedAt { get; set; }

        [JsonProperty("edited")]
        public bool Edited { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("body_html_summary")]
        public string BodyHtmlSummary { get; set; }

        [JsonProperty("body_html_summary_truncated")]
        public bool BodyHtmlSummaryTruncated { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("disliked")]
        public bool Disliked { get; set; }

        [JsonProperty("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonProperty("repost")]
        public bool Repost { get; set; }

        [JsonProperty("reported")]
        public bool Reported { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        [JsonProperty("dislike_count")]
        public int DislikeCount { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }

        [JsonProperty("repost_count")]
        public int RepostCount { get; set; }

        [JsonProperty("is_quote")]
        public bool IsQuote { get; set; }

        [JsonProperty("is_reply")]
        public bool IsReply { get; set; }

        [JsonProperty("attachment")]
        [JsonConverter(typeof(AttachmentConverter))]
        public Attachments Attachments { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("nsfw")]
        public bool Nsfw { get; set; }

        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }

        [JsonProperty("premium_min_tier")]
        public int PremiumMinTier { get; set; }

        [JsonProperty("current_tier")]
        public int CurrentTier { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("only_emoji")]
        public bool OnlyEmoji { get; set; }

        [JsonProperty("is_replies_disabled")]
        public bool IsRepliesDisabled { get; set; }

        [JsonProperty("embed")]
        public Embed Embed { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("category_details")]
        public CategoryDetails CategoryDetails { get; set; }

        [JsonProperty("parent")]
        public Post Parent { get; set; }

        [JsonProperty("replies")]
        public Replies Replies { get; set; }

        [JsonProperty("conversation_parent")]
        public Post ConversationParent { get; set; }

        [JsonProperty("topic")]
        public Topic Topic { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("quote_conversation_parent")]
        public Post QuoteConversationParent { get; set; }
    }
}