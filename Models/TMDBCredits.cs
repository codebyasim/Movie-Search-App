using System.Text.Json.Serialization;

namespace MovieSearchApp.Models
{
    public class TMDBCredits
    {
        [JsonPropertyName("cast")]
        public List<CastMember> Cast { get; set; } = new();

        [JsonPropertyName("crew")]
        public List<CrewMember> Crew { get; set; } = new();
    }

    public class CastMember
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class CrewMember
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("job")]
        public string? Job { get; set; }
    }
}