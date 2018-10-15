using System.Collections.Generic;

namespace Gab.Models
{
    public class Attachments
    {
        public List<MediaAttachment> Media { get; set; }

        public List<UrlAttachment> Url { get; set; }

        public List<YouTubeAttachment> YouTube { get; set; }

        public List<GiphyAttachment> Giphy { get; set; }
    }
}