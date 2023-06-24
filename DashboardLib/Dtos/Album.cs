using System.Text.Json.Serialization;

namespace DashboardLib.Dtos
{
    public partial class Album
    {
        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
