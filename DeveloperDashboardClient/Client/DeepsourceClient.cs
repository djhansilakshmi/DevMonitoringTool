using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeveloperDashboardClient.Client
{
    public class DeepsourceClient : IDeepsourceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _token;
        private readonly string _url;

        public DeepsourceClient(string url, string token)
        {
            _token = token;
            _url = url;
        }
        public async Task<HttpResponseMessage> SendAsync( string data)
        {
            var queryObject = new
            {
                query = data
            };
            var launchQuery = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            Uri uri = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _httpClient.PostAsync(uri, launchQuery).ConfigureAwait(false);
            return response;

        }
    }
}
