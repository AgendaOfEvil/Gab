using Gab.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Gab
{
    public partial class Client
    { 
        public async Task<Response<Feed>> PopularFeed()
        {
            var url = $"https://api.gab.com/v1.0/popular/feed/";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<Feed>>(json, _serializer);
        }

        public async Task<Response<ActUser>> PopularUsers()
        {
            var url = $"https://api.gab.com/v1.0/popular/users/";

            var json = await _httpClient.GetStringAsync(url);

            return JsonConvert.DeserializeObject<Response<ActUser>>(json, _serializer);
        }
    }
}
