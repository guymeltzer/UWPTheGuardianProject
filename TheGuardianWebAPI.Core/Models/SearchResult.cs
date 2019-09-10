using Newtonsoft.Json;

namespace TheGuardianWebAPI.Core.Models
{
    // this is just an object with a property and a refernce to another object SearchResponse
    public class SearchResult
    {
        [JsonProperty(PropertyName = "response")]
        public SearchResponse SearchResponse { get; set; }
    }
}