using Gab.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Gab
{
    public partial class Client
    {
        public async Task<Command> UpVote(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/upvote";

            var msg = await _httpClient.PostAsync(url, null);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> RemoveUpVote(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/upvote";

            var msg = await _httpClient.DeleteAsync(url);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> RemoveDownVote(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/downvote";

            var msg = await _httpClient.DeleteAsync(url);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> DownVote(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/downvote";

            var msg = await _httpClient.PostAsync(url, null);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> RePost(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/repost";

            var msg = await _httpClient.PostAsync(url, null);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> RemoveRePost(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}/repost";

            var msg = await _httpClient.DeleteAsync(url);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Post> PostDetails(long postId)
        {
            var url = $"https://api.gab.com/v1.0/posts/{postId}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Post>(json, _serializer);
        }
    }
}
