using Newtonsoft.Json;

namespace DeveloperDashboardClient.Dtos
{
    public class Deployment
    {
        [JsonProperty("ref")]
        public string BranchName { get; set; }//Ref
        [JsonProperty("id")]

        public int Id { get; set; }
        [JsonProperty("updated_at")]
        public DateTime DeployedDate { get; set; }//updatedAt


    }
}
