namespace MovieSearchApp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = "";
        public string Overview { get; set; } = "";
        public string Genre { get; set; } = "";

        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }

        public string Poster { get; set; } = "";
        public string Actors { get; set; } = "";
        public string Director { get; set; } = "";
        public string Producer { get; set; } = "";
    }
}