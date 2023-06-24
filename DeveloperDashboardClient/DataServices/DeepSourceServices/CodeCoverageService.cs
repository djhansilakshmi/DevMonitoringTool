using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.Dtos;
using Newtonsoft.Json;

namespace DeveloperDashboardClient.DataServices.DeepSourceServices
{
    public class CodeCoverageService : ICodeCoverage
    {
        public readonly IGitClient _gitClientCalls;
        public CodeCoverageService(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        public async Task<CodeCoverage> Get(string owner, string repo, string vcsprovider = "GITHUB")
        {

            var responseContent = string.Empty;
            string url = $"repos/{owner}/{repo}/deployments?state={vcsprovider}";
            responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            var codeCoverage = JsonConvert.DeserializeObject<CodeCoverage>(responseContent);

            return codeCoverage;
        }
    }
}
