using System.Collections.Generic;
using Gab.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Gab
{
    public partial class Client
    {
        public async Task<User> UserDetails()
        {
            var url = "https://api.gab.com/v1.0/me/";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<User>(json, _serializer);
        }

        public async Task<User> UserDetails(string username)
        {
            var url = $"https://api.gab.com/v1.0/users/{username}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<User>(json, _serializer);
        }

        public async Task<Response<List<User>>> Followers(string username, int before = 0)
        {
            var url = $"https://api.gab.com/v1.0/users/{username}/followers?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<User>>>(json, _serializer);
        }

        public async Task<Response<List<User>>> Followed(string username, int before = 0)
        {
            var url = $"https://api.gab.com/v1.0/users/{username}/following?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<User>>>(json, _serializer);
        }
    }
}