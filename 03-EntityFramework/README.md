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
    "Microsoft.EntityFrameworkCore.Tools": {
      "version": "1.0.0-preview2-final",
      "imports": [
        "portable-net45+win8+dnxcore50",
        "portable-net45+win8"
      ]
    }
  }
  ```

1. Set up Entity Framework and register database to Startup.ConfigureServices:

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

1. Inject the database context into the contructor of the controller. While at it, add a logger so we can try it out in a controller. Add the following property and constructor parameter to utilize the logging framework you set up earlier. 

```
private readonly ArticlesContext _context;
private readonly ILogger<ArticlesController> _logger; 

public ArticlesController(ArticlesContext context, ILogger<ArticlesController> logger)
{
    _context = context;
    _logger = logger;
}
```

1. Update the `Get` endpoint in `ArticlesController` to use the database context. You can now remove the _Articles object there.

  `var applicant = await _context.Applicants.SingleOrDefaultAsync(m => m.Id == id);`

You can also add this method, replacing the Hello World method, to return all items added to the database,
  
  ```C#
  public async Task<IEnumerable<Article>> Get() => await _context.Set<Article>().ToListAsync();
  ```

1. Create a method so we can populate the database.
  ```
  [HttpPost]
  public async Task<IActionResult> Create([FromBody]Article article)
  {
      _logger.LogDebug("Starting save");

      if (!ModelState.IsValid)
      {
          return BadRequest(ModelState);
      }

      _context.Articles.Add(new Article { Title = article.Title });
      await _context.SaveChangesAsync();

      _logger.LogDebug("Finished save");

      return CreatedAtAction(nameof(Get), new { id = article.Title }, article);
  }
  ```

Now, from the command line:

1. Build with `dotnet build`
1. Run migrations with:

  `dotnet ef migrations add Initial `

1. Apply the changes:

  `dotnet ef database update`

1. Add an item to the database. You can either use the following curl command, or your favorite tool like Postman:

  `
  curl -H "Content-Type: application/json" -X POST -d '{"title":"I Was Posted"}' http://localhost:5000/api/articles
  `

2. Navigate to the endpoint, [http://localhost:5000:/api/articles](http://localhost:5000:/api/articles).  

You should see your article displayed. You can add more, and notice that you can stop the app and re-run it, and the data persists in the SQLite database.

Also, note the log messages from the statements you added when saving an item.  

### ef commands:

  - add – Add a new migration
  - apply – Apply migrations to the database
  - list – List the migrations
  - script – Generate a SQL script from migrations
  remove – Remove the last migration
  
  Congratulations on completing the Entity Framework section! You can go on to the [Deployment section](04-Deploy section) now.
