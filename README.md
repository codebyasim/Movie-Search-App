# 🎬 Movie Database Presentation Tool

**Search smarter. Explore movies. Discover the details.**

A C# desktop application that brings movie information into one place, combining local database searches with the [TMDB API](https://www.themoviedb.org/) to help users discover movies and explore their details.

[![C#](https://img.shields.io/badge/C%23-.NET-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-0078D4)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQLite](https://img.shields.io/badge/Database-SQLite-003B57?logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![API](https://img.shields.io/badge/Integration-TMDB-01B4E4)](https://developer.themoviedb.org/)

## 📌 The Problem

Finding movie information often means searching across multiple websites to discover a film's genre, cast, director, runtime, budget, and revenue.

**My solution:** a desktop application that brings these details together in one searchable interface, using SQLite for local data and TMDB for external movie information when a local search returns no results.

## ✨ Key Features

- **10 Search Filters** — search by title, overview, genre, release date, runtime, budget, revenue, actors, director, or producer.
- **Local Database Search** — retrieve movie records stored in SQLite.
- **External API Integration** — query TMDB when a movie is not found locally.
- **Detailed Movie Information** — explore descriptions, genres, release dates, financial information, and cast and crew details.
- **Movie Poster Display** — view the poster associated with a selected movie.
- **Desktop User Interface** — interact with movie data through Windows Forms controls and a results grid.

## 🛠️ Technology Stack

| Technology | Purpose |
|---|---|
| C# | Application logic and object-oriented programming |
| .NET 10 | Application runtime and development platform |
| Windows Forms | Desktop user interface |
| SQLite | Local relational database |
| TMDB REST API | External movie data retrieval |
| `HttpClient` | HTTP requests to the API |
| `System.Text.Json` | JSON response deserialization |
| Git and GitHub | Version control and source-code hosting |

## 🏗️ How It Works

```text
          User enters a search
                   |
                   v
          Selects search filter
                   |
                   v
          Search SQLite database
                   |
          +--------+--------+
          |                 |
       Results found     No results
          |                 |
          v                 v
     Display movie       Query TMDB API
       details                |
                              v
                       Parse JSON response
                              |
                              v
                       Display movie details
                       and poster when available
```

## 🚀 Getting Started

### Prerequisites

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Git (optional, for cloning the repository)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/codebyasim/Movie-Search-App.git
   ```

2. Navigate to the project directory:

   ```bash
   cd Movie-Search-App
   ```

3. Run the Windows Forms application:

   ```bash
   dotnet run --project MovieSearchApp.UI
   ```

### TMDB API Configuration

The application uses TMDB to retrieve external movie information and posters.

1. Create an account and obtain an API key from the [TMDB developer portal](https://developer.themoviedb.org/).
2. Configure the key securely using an environment variable or local configuration excluded from version control.
3. Ensure the application reads the configured key before making API requests.

**Security note:** Never commit API keys or other credentials to a public GitHub repository. If a key has already been exposed, rotate it.

## 🧠 Engineering Concepts Demonstrated

- **Object-oriented programming:** organising application functionality into models, repositories, and services.
- **Database integration:** querying and retrieving locally stored movie records.
- **REST API consumption:** requesting data from an external service using HTTP.
- **JSON deserialization:** converting API responses into C# objects.
- **Asynchronous programming:** using asynchronous API calls to support network operations.
- **Data presentation:** displaying structured information in a Windows Forms data grid.
- **Error handling:** an area to strengthen further for network failures, invalid input, and unavailable data.

## 🔮 Future Improvements

- Add automated unit and integration tests.
- Improve validation and user-friendly error messages.
- Add pagination, sorting, and more advanced search.
- Improve database schema constraints and query performance.
- Move API credentials into secure configuration.
- Add loading indicators and clearer API failure states.
- Expand the local movie collection and add database update functionality.

## 🎯 What I Learned

This project helped me apply software engineering concepts to a practical application: connecting a desktop interface to a relational database and an external REST API. It also gave me experience working with asynchronous requests, JSON data, structured C# models, and version control.

## 👨‍💻 Developer

**Asim Iqbal**  
BSc Software Engineering student at Manchester Metropolitan University

**GitHub:** [@codebyasim](https://github.com/codebyasim)

**Repository:** [Movie-Search-App](https://github.com/codebyasim/Movie-Search-App)

---

*Built as a practical software engineering project to explore desktop development, data persistence, and external API integration.*

**Data attribution:** Movie information and imagery are provided by [The Movie Database (TMDB)](https://www.themoviedb.org/). This project is not endorsed or certified by TMDB.
    