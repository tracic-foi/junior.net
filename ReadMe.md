# AbySalto Junior - Restaurant Order Management

REST API za upravljanje narudžbama restorana. Omogućuje kreiranje narudžbi, pregled, sortiranje po ukupnom iznosu i promjenu statusa narudžbe.

## Tech stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core 9
- SQL Server
- Swagger / OpenAPI

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (za pokretanje SQL Server kontejnera)
- EF Core CLI tools: `dotnet tool install --global dotnet-ef`

## Setup

### 1. Pokretanje baze (SQL Server u Dockeru)

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password123!" -p 1433:1433 -d --name abysalto-sql mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Connection string

Connection string se nalazi u `appsettings.Development.json`. Ako koristiš drugu lozinku ili instancu baze, prilagodi:

```json
"DefaultConnection": "Server=localhost;Database=AbySalto;User Id=sa;Password=Password123!;TrustServerCertificate=True;"
```

> Za produkcijsko okruženje preporuča se korištenje [User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) ili environment varijabli umjesto čuvanja lozinke u `appsettings.json`.

### 3. Pokretanje migracija

Iz `AbySalto.Junior` direktorija:

```bash
dotnet ef database update
```

### 4. Pokretanje aplikacije

```bash
dotnet run
```

Aplikacija je dostupna na `https://localhost:{port}` (port se ispiše u terminalu). Swagger UI se otvara automatski na root URL-u.

## API endpoints

| Metoda | Ruta                              | Opis                              |
|--------|-----------------------------------|-----------------------------------|
| POST   | `/api/restaurant`                 | Kreiranje nove narudžbe (total se automatski izračunava) |
| GET    | `/api/restaurant?sortByTotal=true`| Dohvat svih narudžbi (sa sortiranjem) |
| GET    | `/api/restaurant/{id}`            | Dohvat narudžbe po ID-u           |
| PATCH  | `/api/restaurant/{id}/status`     | Promjena statusa narudžbe         |

## Project structure

```
AbySalto.Junior/
├── Controllers/              # HTTP layer
├── Models/
│   ├── Entities/             # Database entities
│   ├── Enums/                # OrderStatus, PaymentType
│   └── DTOs/                 # Data transfer objects
├── Services/                 # Business logic
├── Infrastructure/
│   └── Database/
│       ├── ApplicationDbContext.cs
│       └── Configurations/   # EF Core entity configurations
└── Migrations/               # EF Core migrations
```
