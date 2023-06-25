using Newtonsoft.Json;

namespace DashboardLib.Dtos
{
    public class Branch
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public List<PullRequest> PullRequests { get; set; }

        [JsonProperty("actions")]
        public Actions Actions { get; set; }

        [JsonProperty("deployments")]

        public List<Deployment> Deployments { get; set; }

        public CodeCoverage CodeCoverage { get; set; }
    }
}
