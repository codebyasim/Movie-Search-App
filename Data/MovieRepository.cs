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
    }
}