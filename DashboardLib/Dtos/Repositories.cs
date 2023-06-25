using Newtonsoft.Json;

namespace DashboardLib.Dtos
{
    public class Repositories
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        public List<Branch> Branches { get; set; }


    }
}
