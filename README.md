# Healthcare MVP

ASP.NET Core 8 MVC healthcare platform scaffold using layered architecture:

- `Healthcare.Web` — MVC controllers, views, areas, static assets, and application startup.
- `Healthcare.Application` — application contracts, DTOs, mappings, validators, and services.
- `Healthcare.Domain` — entities, enums, and common domain primitives.
- `Healthcare.Infrastructure` — EF Core, Identity, repositories, Unit of Work, email, QR, and PDF infrastructure.

## Database setup

The application uses SQL Server and reads the connection string named `DefaultConnection` from `Healthcare.Web/appsettings.json`.

### Recommended command-line workflow

Use the .NET EF Core CLI from the repository root:

```bash
dotnet tool restore
dotnet ef database update --project Healthcare.Infrastructure --startup-project Healthcare.Web --context ApplicationDbContext
```

On Windows PowerShell you can also run:

```powershell
./scripts/update-database.ps1
```

On macOS/Linux or Git Bash you can run:

```bash
./scripts/update-database.sh
```

### Visual Studio Package Manager Console workflow

`Update-Database` is a Visual Studio Package Manager Console command, not a regular PowerShell/cmd/bash command. If you want to use it, open **Tools → NuGet Package Manager → Package Manager Console**, then run:

```powershell
Update-Database -Project Healthcare.Infrastructure -StartupProject Healthcare.Web -Context ApplicationDbContext
```

If `Update-Database` is not recognized, you are likely in a normal terminal instead of the Visual Studio Package Manager Console. Use the recommended `dotnet ef database update` command above.
