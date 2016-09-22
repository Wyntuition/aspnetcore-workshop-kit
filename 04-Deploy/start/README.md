## Objectives 
- Replace the static list of products with entity framework in memory store
- Replace the static list with entity framework + sqlite




## Set up Entity Framework and register database

    `services.AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]))
        .AddDbContext<InvoicesDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));`


