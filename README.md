# Library Management System

This repository stores a **.NET REST API** built with Clean Architecture principles. 

This project demonstrates a clear separation of concerns by decoupling business logic from infrastructure. 

It provides an interface for creating and listing books, backed by a SQL database for persistent storage.

More details about technical test can be found [here](INSTRUCTIONS.md). 

## Table of Contents

- [Requirements](#requirements)
- [Configuration](#configuration)
- [Docs](#docs)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Testing](#testing)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [Authors](#authors)

<a name="requirements"></a>
## 📋 Requirements

- **.NET SDK:**  
  - Version: **10.0.102**
  - Download: [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

> **ℹ️ Please make sure to use a Long Term Support (LTS) version of .NET.**  
> LTS releases (even-numbered versions like .NET 6/8/10) receive security updates and support for three years, making them the recommended choice for production projects.
>
> Always keep your .NET SDK up to date.  
> You can check the latest supported LTS versions and their end-of-life dates at [https://versionsof.net/](https://versionsof.net/).

- **SQL Server:**  
  - Version: **2025**
  - Download: [https://dotnet.microsoft.com/en-us/download](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)

<a name="configuration"></a>
## ⚙️ Configuration

Two configuration files:
- **appsettings.json** -> for production environment
- **appsettings.Development.json** -> for development environment

> Note:
> When you clone the project, you must retrieve these configuration files. Do not commit or transfer these files to the GitHub repository, as they contain sensitive information.

#### SQL Server database connection

You must add a specific section in each of these configuration files in order to set up the connection database link with the API.

```json
  ...
  "ConnectionStrings": {
    "DefaultConnection": "Server=...;Database=...;User Id=...;Password=...;..etc."
  },
  ...
```


<a name="docs"></a>
## 📚 Docs
Technical documentation (UML diagrams) is available in the `Docs` folder. All diagrams are created using [Mermaid](https://mermaid.js.org/), which ensures traceability and facilitates maintainability.

<a name="project-structure"></a>
## 🗂️ Project structure

```
├───Docs
├───LibraryManagementSystem.Api
│   ├───Controllers
│   └───Properties
├───LibraryManagementSystem.Application
│   ├───DTOs
│   │   ├───Common
│   │   ├───CreateBook
│   │   ├───ListAuthors
│   │   ├───ListBooks
│   │   ├───ListGenres
│   │   └───ListIllustrators
│   ├───Interfaces
│   └───UseCases
├───LibraryManagementSystem.Domain
│   ├───Exceptions
│   ├───Models
├───LibraryManagementSystem.Infrastructure
│   ├───Database
│   │   └───Migrations
│   └───Repositories
└───LibraryManagementSystem.Tests
```

<a name="usage"></a>
## 🚀 Usage (DEV)

1. `cd .\LibraryManagementSystem.Api\`
2. `dotnet run` -> [http://localhost:5126/swagger](http://localhost:5126/swagger)

<a name="testing"></a>
## 🔬 Testing

1. `cd .\LibraryManagementSystem.Tests\`
2. `dotnet test`

<a name="deployment"></a>
## 🚢 Deployment
Coming soon...

<a name="contributing"></a>
## 🤝 Contributing

1. Clone the repository using SSH (`git clone git@github.com:arlealexandre/LibraryManagementSystem.git`)
2. Go to [dev](https://github.com/arlealexandre/LibraryManagementSystem/tree/dev) branch (`git checkout dev`)
3. Create a new branch branch (`git checkout -b feature/my-feature`)
4. Add your changes (`git add -A`)
5. Commit your changes (`git commit -m 'Add new feature'`)
6. Push to the branch (`git push origin feature/my-feature`)
7. Open a [Pull Request](https://github.com/arlealexandre/LibraryManagementSystem/pulls)

<a name="authors"></a>
## 👥 Authors


- Alexandre Arle – [@arlealexandre](https://github.com/arlealexandre)
