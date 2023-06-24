using DeveloperDashboardAPI.Clients;
using DeveloperDashboardAPI.Dtos;
using Newtonsoft.Json;

namespace DeveloperDashboardClient.Services.GitServices
{
    public class BuildService : IBuildService
    {
        public readonly IGitClient _gitClientCalls;
        public BuildService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<Actions> Get(string owner, string repo)
        {
            var responseContent = string.Empty;
            string url = $"repos/{owner}/{repo}/actions/runs";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);
            var builds = JsonConvert.DeserializeObject<Actions>(responseContent);

            return builds;
        }
    }
}
