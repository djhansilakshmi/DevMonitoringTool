using DashboardLib.Dtos;
using DeveloperDashboardAPI.Clients;
using Newtonsoft.Json;

namespace DeveloperDashboardAPI.DataServices.GitServices
{
    public class DeploymentService : IDeploymentService
    {
        public readonly IGitClient _gitClientCalls;
        public DeploymentService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<List<Deployment>> Get(string owner, string repo, string state = "all")
        {

            var responseContent = string.Empty;
            string url = $"repos/{owner}/{repo}/deployments?state={state}";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            var deployments = JsonConvert.DeserializeObject<List<Deployment>>(responseContent);

            return deployments;
        }
    }
}
