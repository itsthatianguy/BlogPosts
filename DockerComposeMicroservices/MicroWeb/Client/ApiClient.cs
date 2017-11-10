using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MicroWeb.Client
{
    public class ApiClient : IApiClient
    {
        private HttpClient _client = new HttpClient();

        public ApiClient(string baseAddress)
        {
            // TODO: Not a good idea with a static client??
            _client.BaseAddress = new Uri(baseAddress);
        }

        public async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}