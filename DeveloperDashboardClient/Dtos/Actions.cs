using Newtonsoft.Json;

namespace DeveloperDashboardClient.Dtos
{
    public class Actions
    {
        [JsonProperty("workflow_runs")]

        public List<ActionWorkflowRun> ActionWorkflowRuns { get; set; }

    }

    public class ActionWorkflowRun
    {
        //[JsonProperty("repository")]
        //public Repository RepoName { get; set; }

        [JsonProperty("head_branch")]
        public string BranchName { get; set; }

        [JsonProperty("conclusion")]
        public string Conclusion { get; set; }

    }
    public class Repository
    {
        [JsonProperty("name")]
        public string RepositoryName { get; set; }

    }
}
