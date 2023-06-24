using Newtonsoft.Json;

namespace DeveloperDashboardAPI.Dtos
{
    public class Actions
    {
        [JsonProperty("workflow_runs")]

        public List<ActionWorkflowRun> ActionWorkflowRuns { get; set; }

    }

    public class ActionWorkflowRun
    {
        [JsonProperty("id")]
        public long ActionId { get; set; }

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
