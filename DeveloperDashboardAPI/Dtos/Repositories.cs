using Newtonsoft.Json;

namespace DeveloperDashboardAPI.Dtos
{
    public class Repositories
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public List<Branch> Branches { get; set; }

    }
}
