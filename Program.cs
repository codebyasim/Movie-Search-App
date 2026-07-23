using MovieSearchApp.Models;

using MovieSearchApp.Data;

DatabaseHelper.InitializeDatabase();

List<Movie> movies = new List<Movie>
{
    new Movie
    {
        MovieId = 1,
        Title = "Avengers: Endgame",
        Overview = "The Avengers fight to restore the universe.",
        Genre = "Action",
        ReleaseDate = new DateTime(2019, 4, 26),
        Runtime = 181,
        Budget = 356000000,
        Revenue = 2798000000,
        Poster = "posters/avengers-endgame.jpg",

        Actors = "Robert Downey Jr., Chris Evans, Mark Ruffalo, Chris Hemsworth",
        Director = "Anthony Russo, Joe Russo",
        Producer = "Kevin Feige"
    },

    new Movie
    {
        MovieId = 2,
        Title = "Indiana Jones",
        Overview = "An archaeologist goes on a dangerous adventure.",
        Genre = "Adventure",
        ReleaseDate = new DateTime(1981, 6, 12),
        Runtime = 115,
        Budget = 18000000,
        Revenue = 389900000,

        Poster = "posters/indiana-jones.jpg",

        Actors = "Harrison Ford, Karen Allen, Paul Freeman, John Rhys-Davies",
        Director = "Steven Spielberg",
        Producer = "Frank Marshall"
    },

    new Movie
    {
        MovieId = 3,
        Title = "Gladiator",
        Overview = "A Roman general fights for revenge.",
        Genre = "Action",
        ReleaseDate = new DateTime(2000, 5, 5),
        Runtime = 155,
        Budget = 103000000,
        Revenue = 465400000,

        Poster = "posters/gladiator.jpg",

        Actors = "Russell Crowe, Joaquin Phoenix, Connie Nielsen, Oliver Reed",
        Director = "Ridley Scott",
        Producer = "Douglas Wick, David Franzoni, Branko Lustig"
    },

    new Movie
    {
        MovieId = 4,
        Title = "Jumanji",
        Overview = "Players enter a dangerous adventure game.",
        Genre = "Adventure",
        ReleaseDate = new DateTime(1995, 12, 15),
        Runtime = 104,
        Budget = 65000000,
        Revenue = 262800000,

        Poster = "posters/jumanji.jpg",

        Actors = "Robin Williams, Kirsten Dunst, Bonnie Hunt, Jonathan Hyde",
        Director = "Joe Johnston",
        Producer = "Scott Kroopf, William Teitler"
    }
};

    // foreach (Movie movie in movies)
    // {
    // MovieRepository.InsertMovie(movie);
    // }

Console.WriteLine("=== Movie Search Application ===");
Console.WriteLine("1. Search by Title");
Console.WriteLine("2. Search by Overview");
Console.WriteLine("3. Search by Genre");
Console.WriteLine("4. Search by Release Date");
Console.WriteLine("5. Search by Runtime");
Console.WriteLine("6. Search by Budget");
Console.WriteLine("7. Search by Revenue Generated");
Console.WriteLine("8. Search by Actors");
Console.WriteLine("9. Search by Director");
Console.WriteLine("10. Search by Producer");
Console.Write("Choose an option: ");

string choice = Console.ReadLine() ?? "";

Console.Write("Enter search: ");
string search = Console.ReadLine() ?? "";

List<Movie> results = new List<Movie>();

if (choice == "1")
{
    results = movies
        .Where(m => m.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else if (choice == "2")
{
    results = movies
        .Where(m => m.Overview.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else if (choice == "3")
{
    results = movies
        .Where(m => m.Genre.Equals(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else if (choice == "4")
{
    results = movies
        .Where(m => m.ReleaseDate.Year.ToString() == search)
        .ToList();
}
else if (choice == "5")
{
    results = movies
        .Where(m => m.Runtime.ToString() == search)
        .ToList();
}
else if (choice == "6")
{
    results = movies
        .Where(m => m.Budget.ToString() == search)
        .ToList();
}
else if (choice == "7")
{
    results = movies
        .Where(m => m.Revenue.ToString() == search)
        .ToList();
}
else if (choice == "8")
{
    results = movies
        .Where(m => m.Actors.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else if (choice == "9")
{
    results = movies
        .Where(m => m.Director.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else if (choice == "10")
{
    results = movies
        .Where(m => m.Producer.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();
}
else
{
    Console.WriteLine("Invalid option.");
    return;
}

Console.WriteLine("\n=== Search Results ===");

if (results.Count == 0)
{
    Console.WriteLine("No movies found.");
}
else
{
    foreach (Movie movie in results)
    {
        Console.WriteLine("\n----------------------------");
        Console.WriteLine($"Title: {movie.Title}");
        Console.WriteLine($"Overview: {movie.Overview}");
        Console.WriteLine($"Genre: {movie.Genre}");
        Console.WriteLine($"Release Date: {movie.ReleaseDate:dd/MM/yyyy}");
        Console.WriteLine($"Runtime: {movie.Runtime} minutes");
        Console.WriteLine($"Budget: ${movie.Budget:N0}");
        Console.WriteLine($"Revenue Generated: ${movie.Revenue:N0}");
        
        Console.WriteLine("\n--- Cast & Crew ---");
        Console.WriteLine($"Actors: {movie.Actors}");
        Console.WriteLine($"Director: {movie.Director}");
        Console.WriteLine($"Producer: {movie.Producer}");
        Console.WriteLine($"Movie Poster: {movie.Poster}");
    }

}