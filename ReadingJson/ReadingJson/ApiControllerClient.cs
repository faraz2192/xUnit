using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReadingJson
{
    public class ApiControllerClient
    {
        private readonly HttpClient _httpClient;
    
    
        public ApiControllerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetDataFromController<T>(string controllerEndpoint)
        {
            var response = await _httpClient.GetAsync(controllerEndpoint);

            if (response.IsSuccessStatusCode)
            {
                // Read the JSON content as a string
                var jsonContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into the specified type T
                var result = JsonConvert.DeserializeObject<T>(jsonContent);

                return result;
            }
            else
            {
                // Handle the case where the request was not successful
                throw new HttpRequestException($"Request to {controllerEndpoint} failed with status code {response.StatusCode}");
            }
        }
    }
}
