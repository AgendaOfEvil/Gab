using System.Threading.Tasks;
using Gab.Models;
using Newtonsoft.Json;

namespace Gab
{
    public partial class Client
    {
        public async Task<Command> Follow(long userId)
        {
            var url = $"https://api.gab.com/v1.0/users/{userId}/follow";

            var msg = await _httpClient.PostAsync(url, null);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }

        public async Task<Command> UnFollow(long userId)
        {
            var url = $"https://api.gab.com/v1.0/users/{userId}/follow";

            var msg = await _httpClient.DeleteAsync(url);

            var json = await msg.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Command>(json, _serializer);
        }
    }
}