using Newtonsoft.Json;

namespace DeveloperDashboardAPI.Dtos
{
    public class Branch
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public List<PullRequest> PullRequests { get; set; }
        public Actions Actions { get; set; }

        public List<Deployment> Deployments { get; set; }

        public CodeCoverage CodeCoverage { get; set; }
    }
}
