using DeveloperDashboardAPI.Clients;
using Newtonsoft.Json;

namespace DeveloperDashboardAPI.Dtos
{
    public class CodeCoverage
    {
        public readonly IGitClient _gitClientCalls;
        public CodeCoverage(IGitClient gitCalls)
        {
            _gitClientCalls = gitCalls;
        }

        //public async Task<List<Deployment>> Get(string owner, string repo)
       // {

            //var responseContent = string.Empty;
            //string url = $"repos/{owner}/{repo}/code-scanning/summaries/{commitSha}";
            //responseContent = await _gitClientCalls.SendAsync(url).ConfigureAwait(false);

            //var deployments = JsonConvert.DeserializeObject<List<Deployment>>(responseContent);

            //return deployments;
      //  }

        //string apiUrl = $"https://api.github.com/";


    }
}
