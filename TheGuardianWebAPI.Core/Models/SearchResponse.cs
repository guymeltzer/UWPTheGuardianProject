using Newtonsoft.Json;

namespace TheGuardianWebAPI.Core.Models
{
    // these properties are what you receive back from the API meaning every query in JSON has these properties
    public class SearchResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "userTier")]
        public string UserTier { get; set; }
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
        [JsonProperty(PropertyName = "startIndex")]
        public int StartIndex { get; set; }
        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty(PropertyName = "pages")]
        public int Pages { get; set; }
        [JsonProperty(PropertyName = "orderBy")]
        public string OrderBy { get; set; }
        [JsonProperty(PropertyName = "results")]
        // the response you receive has an array of Story Headers
        public StoryHeader[] StoryHeaders { get; set; }
    }
}
