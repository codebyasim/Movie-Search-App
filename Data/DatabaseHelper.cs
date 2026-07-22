using Microsoft.Data.Sqlite;

namespace MovieSearchApp.Data
{
    public class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=movies.db";

        public static void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);

            connection.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Movies
            (
                MovieId INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT,
                Overview TEXT,
                Genre TEXT,
                ReleaseDate TEXT,
                Runtime INTEGER,
                Budget REAL,
                Revenue REAL,
                Poster TEXT,
                Actors TEXT,
                Director TEXT,
                Producer TEXT
            );";

            var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}