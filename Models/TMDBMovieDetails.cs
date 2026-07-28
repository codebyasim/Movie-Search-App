using System.Text.Json.Serialization;

namespace MovieSearchApp.Models
{
    public class TMDBMovieDetails
    {
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("budget")]
        public long Budget { get; set; }

        [JsonPropertyName("revenue")]
        public long Revenue { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = new();
    }

    public class Genre
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}