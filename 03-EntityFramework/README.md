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
    services.AddDbContext<ArticlesContext>(options =>
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

1. Create this context class to represent the database in the Entities folder:

  ```
  namespace ConsoleApplication.Infrastructure
  {
    public class ArticlesContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./articles.db");
        }
    }
  }
  ```

1. Create a method so we can populate the database.
  ```
  [HttpPost]
  public async Task<IActionResult> Create([FromBody]Article article)
  {
      if (!ModelState.IsValid)
      {
          return BadRequest(ModelState);
      }

      _context.Attendees.Add(article);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Get), new { id = article.Id }, article);
  }
  ```

1. Use the database context in the API controller:

  ```
  private readonly ArticlesContext _context;

  public ArticlesController(ArticlesContext context)
  {
      _context = context;
  }
  ```

Now, from the command line:

1. Build
1. Run migrations with:

  `dotnet ef migrations add Initial `

1. Apply the changes:

  `dotnet ef database update`

1. Add an item to the database. You can either use the following curl command, or your favorite tool like Postman:

  `
  curl -H "Content-Type: application/json" -X POST -d '{"title":"I Was Posted"}' http://localhost:5000/api/articles
  `

1. Update the get endpoint to get our added item. You can also add this method, replacing the Hello World method, to return all items,

  ```C#
  public async Task<IEnumerable<Article>> Get() => await _context.Set<Article>().ToListAsync();
  ```

ef commands:

  - add – Add a new migration
  - apply – Apply migrations to the database
  - list – List the migrations
  - script – Generate a SQL script from migrations
  remove – Remove the last migration
