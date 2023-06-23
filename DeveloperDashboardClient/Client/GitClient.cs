using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DeveloperDashboardClient.Client
{
    public class GitClient : IGitClient
    {
        private HttpClient _httpClient;
        private readonly string _token;
        private const string _gitUrl = "https://api.github.com/repos";
        public GitClient(string token)
        {
            _token = token;
        }
        public async Task<string> SendAsync(string url)
        {
            string responseContent = string.Empty;

            using (_httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(_gitUrl);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", $"Bearer {_token}");
                request.Headers.Add("User-Agent", $"Awesome-Octocat-App");
                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                    responseContent = await response.Content.ReadAsStringAsync();
            }
            return responseContent;

        }
    }
}
