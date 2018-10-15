using System;
using System.Collections.Generic;
using Gab.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gab.Converters
{
    internal class GroupUsersConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = JObject.Load(reader);

            var data = item["data"]?.Value<JArray>();

            var users = data?.ToObject<List<ActUser>>();

            return users;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}