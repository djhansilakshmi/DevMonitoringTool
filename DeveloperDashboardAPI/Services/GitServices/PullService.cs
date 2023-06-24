using DashboardLibAPI.Dtos;
using DeveloperDashboardAPI.Clients;
using Newtonsoft.Json;
using System.Dynamic;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public class PullService : IPullService
    {
        public readonly IGitClient _gitClientCalls;
        public PullService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<List<PullRequest>> Get(string owner, string repo, string state = "all")
        {

            var responseContent = string.Empty;
            string url = $"repos/{owner}/{repo}/pulls?state={state}";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);
            var pulls = JsonConvert.DeserializeObject<List<PullRequest>>(responseContent);

            return pulls;
        }
    }
}
