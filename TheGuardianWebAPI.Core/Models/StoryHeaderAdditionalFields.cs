using HtmlAgilityPack;
using Newtonsoft.Json;
using System;

namespace TheGuardianWebAPI.Core.Models
{
    // the response you get back from the API has the story header and also additional fields|
    // that is why another class was created to accomodate these extra fields and properties
    public class StoryHeaderAdditionalFields
    {
        [JsonProperty(PropertyName = "trailText")]
        public string TrailText { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime LastModified { get; set; }
        [JsonProperty(PropertyName = "byline")]
        public string Byline { get; set; }
        //TrailText contains HTML, that's why we convert it to an HTML page and remove the tags etc leaving only text we want
        public string TrailTextString
        {
            get
            {
                if (TrailText != null)
                {
                    HtmlDocument html = new HtmlDocument();
                    html.LoadHtml(TrailText);
                    return html.DocumentNode.InnerText;
                }
                return null;
            }
        }

        public string BylineString
        {
            get
            {
                if (Byline != null)
                {
                    HtmlDocument html = new HtmlDocument();
                    html.LoadHtml(Byline);
                    return html.DocumentNode.InnerText;
                }
                return null;
            }
        }
    }
}
