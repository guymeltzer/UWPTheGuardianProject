using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGuardianWebAPI.Core
{
    public class HttpService
    {
        //this function performs a call to the client and adds the parameters to BaseURL at the end of the string
        public async Task<T> GetAsync<T>(string baseUrl, Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                var finalUrl = baseUrl + GetParametersString(parameters);

                // this is the call that is later saved in a variable named response
                var response = await client.GetAsync(finalUrl);
                response.EnsureSuccessStatusCode();

                //here the JSON is being converted and serialized
                var resultJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(resultJson);
            }
        }

        //this function recieves a dictionary and returns a string of paremeters for the URL
        //in the dictionary there are pairs of key and value which are turned to strings
        //that string is then converted into the final URL using the function above "GetAsync"
        private string GetParametersString(Dictionary<string, string> parameters)
        {
            if (parameters?.Any() != true)
                return string.Empty;

            var parametersString = new StringBuilder("?");
            foreach (var parameter in parameters)
            {
                parametersString.Append($"{parameter.Key}={parameter.Value}&");
            }

            parametersString.Remove(parametersString.Length - 1, 1);

            return parametersString.ToString();
        }

    }
}