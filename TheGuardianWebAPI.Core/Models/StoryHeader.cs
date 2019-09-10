using Newtonsoft.Json;

namespace TheGuardianWebAPI.Core.Models
{
    public class StoryHeader
    {
        // every story or article has these particular properties
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "sectionId")]
        public string SectionId { get; set; }
        [JsonProperty(PropertyName = "sectionName")]
        public string SectionName { get; set; }
        [JsonProperty(PropertyName = "webPublicationDate")]
        public System.DateTime WebPublicationDate { get; set; }
        [JsonProperty(PropertyName = "webTitle")]
        public string WebTitle { get; set; }
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }
        [JsonProperty(PropertyName = "apiUrl")]
        public string ApiUrl { get; set; }
        [JsonProperty(PropertyName = "fields")]
        public StoryHeaderAdditionalFields StoryHeaderAdditionalFields { get; set; }
        [JsonProperty(PropertyName = "isHosted")]
        public bool IsHosted { get; set; }
    }
}
