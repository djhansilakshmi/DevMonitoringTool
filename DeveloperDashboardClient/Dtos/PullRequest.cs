using Newtonsoft.Json;

namespace DeveloperDashboardClient.Dtos
{
    public class PullRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("state")]

        public string State { get; set; }

        [JsonProperty("head")]

        public head head { get; set; }



    }

    public class head
    {
        [JsonProperty("ref")]
        public string BranchName { get; set; }

        [JsonProperty("repo")]
        public repo repo { get; set; }
    }

    public class repo
    {
        [JsonProperty("name")]
        public string BranchName { get; set; }

    }


}
