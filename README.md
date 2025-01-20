# Anime Voices

AnimeVoices is a desktop application designed to help anime fans discover connections between their favorite characters and the talented voice actors (Seiyuu) who bring them to life. With AnimeVoices, you can explore anime characters voiced by the same Seiyuu, save your favorites, and access the data even while offline.



## Features

- **Character Exploration**: Search for anime characters and learn more about the Seiyuu who voiced them  
- **Offline Access**: Save the retrieved data locally to browse your collection without an internet connection



## Technology Stack

- **[Avalonia UI](https://avaloniaui.net)**: A powerful, cross-platform UI framework for .NET applications, enabling a beautiful and responsive desktop interface
- **[.NET 8.0](https://learn.microsoft.com/en-gb/dotnet/core/introduction)**: Modern, high-performance runtime environment used to build and run the application


## Dependencies

This application is built on modern .NET technology and uses the following libraries:

- **[SQLite](https://www.sqlite.org/index.html)**: Lightweight, efficient database engine for storing anime data
- **[EF Core](https://docs.microsoft.com/en-us/ef/core/)**: Entity Framework Core is used for object-relational mapping (ORM) with SQLite
- **[CommunityToolkit.Mvvm](https://docs.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)**: Simplifies MVVM patterns with attributes, commands, and observable properties
- **[Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)**: Provides Dependency Injection for better app scalability and maintainability
- **And More**



## Data Source

AnimeVoices fetches its data from the [Jikan API](https://jikan.moe), a RESTful API for retrieving information from [MyAnimeList](https://myanimelist.net). This allows the app to deliver up-to-date information about anime, characters, and voice actors



## License

This project is open-source and available under the MIT license
