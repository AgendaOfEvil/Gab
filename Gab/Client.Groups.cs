using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Gab.Models;

namespace Gab
{
    public partial class Client
    {
        public async Task<Response<List<Group>>> PopularGroups()
        {
            var url = $"https://api.gab.com/v1.0/groups";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<Group>>>(json, _serializer);
        }

        public async Task<GroupExt> GroupDetails(string groupId)
        {
            var url = $"https://api.gab.com/v1.0/groups/{groupId}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<GroupExt>(json, _serializer);
        }

        public async Task<Response<List<User>>> GroupUsers(string groupId, int before = 0)
        {
            var url = $"https://api.gab.com/v1.0/groups/{groupId}/users?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<List<User>>>(json, _serializer);
        }

        public async Task<object> GroupModerationLogs(string groupId)
        {
            // TODO: Find out the what this needs - GroupModerationLogs

            var url = $"https://api.gab.com/v1.0/groups/{groupId}/moderation-logs";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<object>(json, _serializer);
        }
    }
}
