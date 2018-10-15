using System.Net.Http;
using Newtonsoft.Json;

namespace Gab
{
    public partial class Client
    {
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _serializer;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _serializer = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }
    }
}