using Microsoft.Data.Sqlite;
using MovieSearchApp.Models;

namespace MovieSearchApp.Data
{
    public class MovieRepository
    {
        private const string ConnectionString = "Data Source=movies.db";

        public static void InsertMovie(Movie movie)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string sql = @"
            INSERT INTO Movies
            (Title, Overview, Genre, ReleaseDate, Runtime, Budget, Revenue,
             Poster, Actors, Director, Producer)
            VALUES
            (@Title, @Overview, @Genre, @ReleaseDate, @Runtime, @Budget,
             @Revenue, @Poster, @Actors, @Director, @Producer);";

            var cmd = new SqliteCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Overview", movie.Overview);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Runtime", movie.Runtime);
            cmd.Parameters.AddWithValue("@Budget", movie.Budget);
            cmd.Parameters.AddWithValue("@Revenue", movie.Revenue);
            cmd.Parameters.AddWithValue("@Poster", movie.Poster);
            cmd.Parameters.AddWithValue("@Actors", movie.Actors);
            cmd.Parameters.AddWithValue("@Director", movie.Director);
            cmd.Parameters.AddWithValue("@Producer", movie.Producer);

            cmd.ExecuteNonQuery();
        }

            // GET ALL MOVIES FROM SQLITE
        public static List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            using var connection =
                new SqliteConnection(ConnectionString);

            connection.Open();

            string sql = "SELECT * FROM Movies";

            using var command =
                new SqliteCommand(sql, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Movie movie = new Movie
                {
                    MovieId = Convert.ToInt32(reader["MovieId"]),

                    Title =
                        reader["Title"].ToString() ?? "",

                    Overview =
                        reader["Overview"].ToString() ?? "",

                    Genre =
                        reader["Genre"].ToString() ?? "",

                    ReleaseDate = DateTime.Parse(
                        reader["ReleaseDate"].ToString() ?? ""
                    ),

                    Runtime =
                        Convert.ToInt32(reader["Runtime"]),

                    Budget =
                        Convert.ToDecimal(reader["Budget"]),

                    Revenue =
                        Convert.ToDecimal(reader["Revenue"]),

                    Poster =
                        reader["Poster"].ToString() ?? "",

                    Actors =
                        reader["Actors"].ToString() ?? "",

                    Director =
                        reader["Director"].ToString() ?? "",

                    Producer =
                        reader["Producer"].ToString() ?? ""
                };

                movies.Add(movie);
            }

            return movies;
        }
    }
}
