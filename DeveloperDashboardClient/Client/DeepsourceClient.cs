using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DeveloperDashboardClient.Client
{
    public class DeepsourceClient : IDeepsourceClient
    {
        private HttpClient _httpClient;
        private readonly string _token;
        private const string _gitUrl = "https://api.deepsource.io/graphql/";
        public DeepsourceClient(string token)
        {
            _token = token;
        }
        public async Task<string> SendAsync(string url ,  string data)
        {
            string responseContent = string.Empty;
            var queryObject = new
            {
                query = data
            };


            using (_httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(_gitUrl);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", $"Bearer {_token}");
                var launchQuery = new StringContent(JsonConvert.SerializeObject(queryObject), Encoding.UTF8, "application/json");
                //request.Headers.Add("User-Agent", $"Awesome-Octocat-App");
                var response = await _httpClient.PostAsync(url, launchQuery);

                if (response.IsSuccessStatusCode)
                    responseContent = await response.Content.ReadAsStringAsync();
            }
            return responseContent;

        }
    }
}
