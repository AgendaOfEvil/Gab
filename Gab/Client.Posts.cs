using Gab.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gab
{
    public partial class Client
    {
        //public async Task<Post> CreatePost(string body = "", string mediaAttachmentId = "", long replyTo = 0,
        //    bool isQuote = false, bool Nsfw = false, int premiumMinTier = 0,
        //    string group = "", string topic = "", bool poll = false, string pollOption1 = "", string pollOption2 = "",
        //    string pollOption3 = "", string pollOption4 = "")
        //{ 
        //    return await CreatePost(body, new[] { mediaAttachmentId }, replyTo, isQuote, Nsfw, premiumMinTier, group, topic, poll, pollOption1,  pollOption2, pollOption3, pollOption4);
        //}

        public async Task<Response<Feed>> CreatePost(string body = "", string[] mediaAttachmentIds = null, long replyTo = 0, bool isQuote = false, bool Nsfw = false, int premiumMinTier = 0,
            string group = "", string topic = "", bool poll = false, string pollOption1 = "", string pollOption2 = "", string pollOption3 = "", string pollOption4 = "")
        {
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(body)) parameters.Add("body", body);

            if (mediaAttachmentIds != null)
            {
                foreach (var mediaAttachmentId in mediaAttachmentIds)
                {
                    parameters.Add("media_attachments[]", mediaAttachmentId);
                }
            }

            if (replyTo > 0) parameters.Add("reply_to", replyTo);
            if (isQuote) parameters.Add("is_quote", 1);
            if (Nsfw) parameters.Add("Nsfw", 1);
            if (premiumMinTier > 150) parameters.Add("premium_min_tier", premiumMinTier);
            if (!string.IsNullOrEmpty(group)) parameters.Add("group", group);
            if (!string.IsNullOrEmpty(topic)) parameters.Add("topic", topic);
            if (poll) parameters.Add("poll", poll);
            if (!string.IsNullOrEmpty(pollOption1)) parameters.Add("poll_option_1", pollOption1);
            if (!string.IsNullOrEmpty(pollOption2)) parameters.Add("poll_option_2", pollOption2);
            if (!string.IsNullOrEmpty(pollOption3)) parameters.Add("poll_option_3", pollOption3);
            if (!string.IsNullOrEmpty(pollOption4)) parameters.Add("poll_option_4", pollOption4);

            var multipartFormDataContent = new MultipartFormDataContent();

            foreach (var keyValuePair in parameters.Where(x => x.Value != null))
            {
                multipartFormDataContent.Add(new StringContent(keyValuePair.Value.ToString()), $"\"{keyValuePair.Key}\"");
            }

            var response = await _httpClient.PostAsync("https://api.gab.com/v1.0/posts", multipartFormDataContent);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<Feed>>(json, _serializer);

            return result;
        }

        public async Task<string> CreateMediaAttachment(string base64Img)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("file", base64Img);

            var multipartFormDataContent = new MultipartFormDataContent();

            foreach (var keyValuePair in parameters.Where(x => x.Value != null))
            {
                multipartFormDataContent.Add(new StringContent(keyValuePair.Value.ToString()), $"\"{keyValuePair.Key}\"");
            }

            var response = await _httpClient.PostAsync("https://api.gab.com/v1.0/media-attachments/images", multipartFormDataContent);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<MediaAttachmentId>(json);

            return result.Id;
        }
    }
}
