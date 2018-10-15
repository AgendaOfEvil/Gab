using System.Threading.Tasks;
using Gab.Models;
using Newtonsoft.Json;

namespace Gab
{
    public partial class Client
    {
        public async Task<Response<Notification>> Notifications(long? before = null)
        {
            var url = $"https://api.gab.com/v1.0/notifications/?before={before}";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<Notification>>(json, _serializer);
        } 
    }
}