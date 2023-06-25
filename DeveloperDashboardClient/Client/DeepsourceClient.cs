using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeveloperDashboardClient.Client
{
    public class DeepsourceClient : IDeepsourceClient
    {
        private HttpClient _httpClient;
        private readonly string _token;
        private readonly string _url;

        public DeepsourceClient(string url, string token)
        {
            _token = token;
            _url = url;
        }

        public async Task<string> SendAsync(string data)
        {
            string responseContent = string.Empty;
            var queryObject = new
            {
                query = data
            };

            using (_httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(_url);
                var request = new HttpRequestMessage(HttpMethod.Post, _url);
                request.Headers.Add("Authorization", $"Bearer {_token}");
                request.Content = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json"); ;
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    responseContent = await response.Content.ReadAsStringAsync();

            }
            return responseContent;
        }

    }
}
