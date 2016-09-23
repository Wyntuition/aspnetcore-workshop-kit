## Objectives
- Set up Entity Framework Core 1.0
- Connect to a database (SQLite in this case)

## Set up database context and other standard Entity Framework infrastructure

1. Add these dependencies and tools for Entity Framework and SQLite, as we'll use this lightweight database for our app:

  ```
  "Microsoft.EntityFrameworkCore.Design": {
    "version": "1.0.0-preview2-final",
    "type": "build"
  },
  "Microsoft.EntityFrameworkCore.Sqlite": "1.0.0"
  ...
  "tools": {
    "Microsoft.EntityFrameworkCore.Tools": "1.0.0"
  }
  ```

1. Set up Entity Framework and register database

  ```
  services.AddEntityFramework()
      .AddSqlServer()
      .AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]))
      .AddDbContext<InvoicesDbContext>(options =>
              options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
    ```

    ```
    services.AddDbContext<WorkshopContext>(options =>
        {
            options.UseSqlite(Configuration.GetConnectionString("Articles"));
        });
    ```


1. Add the connection string to appSettings:
  ```

  {
  ...
    "ConnectionStrings" : {
        "Articles": "Data Source=articles.db"
    },
  ```

1. Create this context class to represent the database:

  ```
  public class ArticlesContext : DbContext
  {
      public DbSet<Article> Articles { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
          optionsBuilder.UseSqlite("Filename=./articles.db");
      }
  }
  ```

1.
- Build
- Run migrations with

  `dotnet ef migrations add Initial `

- apply the changes:

  `dotnet ef database update`

1. Add an item to the database. We'll add an an API POST method to achieve this:

1. Now run this to add an item:

1. Update the get endpoint to get our added item.
