namespace MovieSearchApp.UI;

public partial class Form1 : Form
{
    private TextBox searchBox;
    private ComboBox searchBy;
    private Button searchButton;
    private Button clearButton;
    private Label titleLabel;

    private DataGridView movieGrid;

    public Form1()
    {
        InitializeComponent();

        // Window
        Text = "Movie Search Database";
        Width = 1000;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;

        // Title
        titleLabel = new Label();
        titleLabel.Text = "MOVIE SEARCH DATABASE";
        titleLabel.Font = new Font("Arial", 22, FontStyle.Bold);
        titleLabel.AutoSize = true;
        titleLabel.Location = new Point(300, 40);

        // Search box
        searchBox = new TextBox();
        searchBox.PlaceholderText = "Enter your search...";
        searchBox.Width = 400;
        searchBox.Location = new Point(100, 120);

        // Search filter
        searchBy = new ComboBox();
        searchBy.Width = 200;
        searchBy.Location = new Point(520, 120);
        searchBy.DropDownStyle = ComboBoxStyle.DropDownList;

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

        // Search button
        searchButton = new Button();
        searchButton.Text = "Search";
        searchButton.Width = 100;
        searchButton.Height = 30;
        searchButton.Location = new Point(740, 118);

        // Clear button
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

        // Movie results table
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


        // Add controls
        Controls.Add(titleLabel);
        Controls.Add(searchBox);
        Controls.Add(searchBy);
        Controls.Add(searchButton);
        Controls.Add(clearButton);
        Controls.Add(movieGrid);
    }

}