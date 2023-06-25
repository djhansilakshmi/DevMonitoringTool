using Newtonsoft.Json;

namespace DashboardLibAPI.Dtos
{
    public class PullRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("state")]

        public string State { get; set; }

        [JsonProperty("head")]

        public Head Head { get; set; }
    }

    public class Head
    {
        [JsonProperty("ref")]
        public string BranchName { get; set; }

        [JsonProperty("repo")]
        public Repo Repo { get; set; }
    }

    public class Repo
    {
        [JsonProperty("name")]
        public string BranchName { get; set; }
    }
}
