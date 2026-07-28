using System.Net.Http;
using System.Text.Json;
using MovieSearchApp.Models;

namespace MovieSearchApp.Services
{
    public class TMDBService
    {
        private readonly HttpClient client = new HttpClient();

        private const string ApiKey = "18b9c0a7f79d5d82027a139f3417575d";

        //Method 1
        public async Task<TMDBResponse> SearchMovieAsync(string title)
        {
            string url =
                $"https://api.themoviedb.org/3/search/movie?api_key={ApiKey}&query={title}";

            string json = await client.GetStringAsync(url);

            TMDBResponse? response =
                JsonSerializer.Deserialize<TMDBResponse>(json);

            return response ?? new TMDBResponse();
        }
        //Method 2
        public async Task<TMDBMovieDetails> GetMovieDetailsAsync(int movieId)
        {
            string url =
                 $"https://api.themoviedb.org/3/movie/{movieId}?api_key={ApiKey}";

            string json = await client.GetStringAsync(url);

            TMDBMovieDetails? details =
                JsonSerializer.Deserialize<TMDBMovieDetails>(json);

            return details ?? new TMDBMovieDetails();
        }
    }
}