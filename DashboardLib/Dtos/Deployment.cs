using Newtonsoft.Json;

namespace DashboardLib.Dtos
{
    public class Deployment
    {
        [JsonProperty("ref")]
        public string BranchName { get; set; }//Ref

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("creator")]
        public CreatorDetails CreatorDetails { get; set; }

        [JsonProperty("updated_at")]
        public DateTime DeployedDate { get; set; }//updatedAt
    }

    public class CreatorDetails
    {
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
