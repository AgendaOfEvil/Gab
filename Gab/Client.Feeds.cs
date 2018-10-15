using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gab.Models;

namespace Gab
{
    public partial class Client
    {
        public async Task<Response<List<Feed>>> MainFeed(DateTimeOffset? before = null)
        {
            var url = $"https://api.gab.com/v1.0/feed/?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<Feed>>>(json, _serializer);
        }

        public async Task<Response<List<Feed>>> UserFeed(string username, DateTimeOffset? before = null)
        {
            var url = $"https://api.gab.com/v1.0/users/{username}/feed/?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<Feed>>>(json, _serializer);
        }
    }
}
