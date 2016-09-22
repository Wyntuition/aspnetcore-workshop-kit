## Objectives 
- Replace the static list of products with entity framework in memory store
- Replace the static list with entity framework + sqlite



## Set up database context, repository, and other standard Entity Framework infrastructure 


## 1. Set up Entity Framework and register database

    `services.AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]))
        .AddDbContext<InvoicesDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));`


## 2. Add the connection string to appSettings: 
```
{
...
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-WebApplication1-26e8893e-d7c0-4fc6-8aab-29b59971d622;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
```