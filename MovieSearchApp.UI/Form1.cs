using MovieSearchApp.Data;
using MovieSearchApp.Models;
using MovieSearchApp.Services;
using System.Linq;

namespace MovieSearchApp.UI;

public partial class Form1 : Form
{   
    // Global variables
    private TextBox searchBox;
    private ComboBox searchBy;
    private Button searchButton;
    private Button clearButton;
    private Label titleLabel;
    private DataGridView movieGrid;

    // Constructor
    public Form1()
    {
        InitializeComponent();

        // Window
        Text = "Movie Search Database";
        Width = 1000;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;

        // Create Title Label
        titleLabel = new Label();
        titleLabel.Text = "MOVIE SEARCH DATABASE";
        titleLabel.Font = new Font("Arial", 22, FontStyle.Bold);
        titleLabel.AutoSize = true;
        titleLabel.Location = new Point(300, 40);

        // Create TextBox
        searchBox = new TextBox();
        searchBox.PlaceholderText = "Enter your search...";
        searchBox.Width = 400;
        searchBox.Location = new Point(100, 120);

        // cretae comboBox
        searchBy = new ComboBox();
        searchBy.Width = 200;
        searchBy.Location = new Point(520, 120);
        searchBy.DropDownStyle = ComboBoxStyle.DropDownList;

        // Add search options by range
        searchBy.Items.AddRange(new string[]
        {
            "Title",
            "Overview",
            "Genre",
            "Release Date",
            "Runtime",
            "Budget",
            "Revenue Generated",
            "Actors",
            "Director",
            "Producer"
        });

        searchBy.SelectedIndex = 0;

        // Create new  button
        searchButton = new Button();
        searchButton.Text = "Search";
        searchButton.Width = 100;
        searchButton.Height = 30;
        searchButton.Location = new Point(740, 118);
        searchButton.Click += SearchButton_Click;

        // Clear new clear button
        clearButton = new Button();
        clearButton.Text = "Clear";
        clearButton.Width = 100;
        clearButton.Height = 30;
        clearButton.Location = new Point(850, 118);

        clearButton.Click += (sender, e) =>
        {
            searchBox.Clear();
            searchBy.SelectedIndex = 0;
        };

        // Create DataGridView
        movieGrid = new DataGridView();

        movieGrid.Location = new Point(100, 210);
        movieGrid.Width = 840;
        movieGrid.Height = 300;

        movieGrid.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;

        movieGrid.ScrollBars = ScrollBars.Both;

        movieGrid.ReadOnly = true;
        movieGrid.AllowUserToAddRows = false;

        movieGrid.Columns.Add("Title", "Title");
        movieGrid.Columns.Add("Overview", "Overview");
        movieGrid.Columns.Add("Genre", "Genre");
        movieGrid.Columns.Add("ReleaseDate", "Release Date");
        movieGrid.Columns.Add("Runtime", "Runtime");
        movieGrid.Columns.Add("Budget", "Budget");
        movieGrid.Columns.Add("Revenue", "Revenue");
        movieGrid.Columns.Add("Actors", "Actors");
        movieGrid.Columns.Add("Director", "Director");
        movieGrid.Columns.Add("Producer", "Producer");

        movieGrid.EnableHeadersVisualStyles = false;

        searchBy.SelectedIndexChanged += (sender, e) =>
    {
        HighlightSelectedColumn();
    };  

        // Add controls
        Controls.Add(titleLabel);
        Controls.Add(searchBox);
        Controls.Add(searchBy);
        Controls.Add(searchButton);
        Controls.Add(clearButton);
        Controls.Add(movieGrid);
    }

    // Method 1
    private async void SearchButton_Click(object? sender, EventArgs e)
{       

    string search = searchBox.Text.Trim();
    string filter = searchBy.SelectedItem?.ToString() ?? "Title";

    List<Movie> movies = MovieRepository.GetAllMovies();

    List<Movie> results = filter switch
    {
        "Title" => movies.Where(m =>
            m.Title.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        "Overview" => movies.Where(m =>
            m.Overview.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        "Genre" => movies.Where(m =>
            m.Genre.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        "Release Date" => movies.Where(m =>
            m.ReleaseDate.Year.ToString().Contains(search)).ToList(),

        "Runtime" => movies.Where(m =>
            m.Runtime.ToString().Contains(search)).ToList(),

        "Budget" => movies.Where(m =>
            m.Budget.ToString().Contains(search)).ToList(),

        "Revenue Generated" => movies.Where(m =>
            m.Revenue.ToString().Contains(search)).ToList(),

        "Actors" => movies.Where(m =>
            m.Actors.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        "Director" => movies.Where(m =>
            m.Director.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        "Producer" => movies.Where(m =>
            m.Producer.Contains(search,
            StringComparison.OrdinalIgnoreCase)).ToList(),

        _ => new List<Movie>()
    };

    //
    if (results.Count == 0)
{
    var service = new TMDBService();

    TMDBResponse response =
        await service.SearchMovieAsync(search);

    movieGrid.Rows.Clear();

    foreach (TMDBMovie movie in response.Results)
    {
         TMDBMovieDetails details =
        await service.GetMovieDetailsAsync(movie.Id);

        movieGrid.Rows.Add(
            movie.Title,
            movie.Overview,
             string.Join(", ", details.Genres.Select(g => g.Name)),
            movie.ReleaseDate,
            details.Runtime,
            $"${details.Budget:N0}",
            $"${details.Revenue:N0}",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        );
    }

    return;
}

    movieGrid.Rows.Clear();

    foreach (Movie movie in results)
    {
        movieGrid.Rows.Add(
            movie.Title,
            movie.Overview,
            movie.Genre,
            movie.ReleaseDate.ToString("dd/MM/yyyy"),
            movie.Runtime,
            $"${movie.Budget:N0}",
            $"${movie.Revenue:N0}",
            movie.Actors,
            movie.Director,
            movie.Producer
        );
    }

    if (results.Count == 0)
    {
        MessageBox.Show("No movies found.");
    }

}

    //Method 2
   private void HighlightSelectedColumn()
{
    string selected = searchBy.SelectedItem?.ToString() ?? "Title";

    string columnName = selected switch
    {
        "Title" => "Title",
        "Overview" => "Overview",
        "Genre" => "Genre",
        "Release Date" => "ReleaseDate",
        "Runtime" => "Runtime",
        "Budget" => "Budget",
        "Revenue Generated" => "Revenue",
        "Actors" => "Actors",
        "Director" => "Director",
        "Producer" => "Producer",
        _ => "Title"
    };

    // Hide all 10 columns
    foreach (DataGridViewColumn column in movieGrid.Columns)
    {
        column.Visible = false;
    }

    // Show only selected column
    if (movieGrid.Columns.Contains(columnName))
    {
        movieGrid.Columns[columnName].Visible = true;

        // Make selected column fill the table
        movieGrid.Columns[columnName].AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill;

        // Highlight header
        movieGrid.Columns[columnName].HeaderCell.Style.BackColor =
            Color.Yellow;
    }
}
}