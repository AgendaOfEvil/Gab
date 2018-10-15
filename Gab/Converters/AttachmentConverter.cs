using System;
using System.Collections.Generic;
using Gab.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gab.Converters
{
    internal class AttachmentConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var attachments = new Attachments();

            var item = JObject.Load(reader);

            var type = item["type"]?.Value<string>();

            switch (type)
            {
                case "url":
                {
                    attachments.Url = new List<UrlAttachment>();

                    if (item["value"] is JArray)
                    {
                        var objs = JsonConvert.DeserializeObject<List<UrlAttachment>>(item["value"].ToString());

                        attachments.Url.AddRange(objs);

                        break;
                    }

                    var obj = JsonConvert.DeserializeObject<UrlAttachment>(item["value"].ToString());

                    attachments.Url.Add(obj);

                    break;
                }
                case "giphy":
                {
                    attachments.Giphy = new List<GiphyAttachment>();

                    var result = new GiphyAttachment();
                    result.Id = item["value"].Value<string>();

                    attachments.Giphy.Add(result);

                    break;
                }
                case "youtube":
                {
                    attachments.YouTube = new List<YouTubeAttachment>();

                    var result = new YouTubeAttachment();
                    result.Id = item["value"].Value<string>();

                    attachments.YouTube.Add(result);

                    break;
                }
                case "media":
                {
                    attachments.Media = new List<MediaAttachment>();

                    if (item["value"] is JArray)
                    {
                        var objs = JsonConvert.DeserializeObject<List<MediaAttachment>>(item["value"].ToString());

                        attachments.Media.AddRange(objs);
                    }

                    break;
                }
            }

            return attachments;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}