using System.Text.Json.Serialization;

namespace MovieSearchApp.Models
{
    public class TMDBResponse
    {
        [JsonPropertyName("results")]
        public List<TMDBMovie> Results { get; set; } = new();
    }

    public class TMDBMovie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
    }
}