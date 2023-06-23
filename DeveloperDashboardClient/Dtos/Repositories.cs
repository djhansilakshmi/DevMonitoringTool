using Newtonsoft.Json;

namespace DeveloperDashboardClient.Dtos
{
    public class Repositories
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public List<Branch> Branches { get; set; }


    }
}
