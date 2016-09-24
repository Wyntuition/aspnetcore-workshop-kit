## Step 1: Set up an API
Set up a basic endpoint with the Web API

## Objectives
- Set the Web API's dependencies and add it into the app via MVC (since it's in the same package)
- Set up a basic endpoint

## Let's get started

1. Set up MVC! The Web API has been merged into MVC, so it's all one package. Start by adding this dependency for MVC to project.json. You will have to use your IDE to add using statements in the files referenced,

    ```
    "Microsoft.AspNetCore.Mvc": "1.0.0"
    ```

2. Add this method to the Startup class:

    ```
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore();
    }
    ```

3. Add this line to the Configure method in Startup:

    ```
    app.UseMvc();
    ```

4. Add a controller to serve the API requests called `ArticlesController` and add the following.

    ```
    [Route("/api/[controller]")]
    public class ArticlesController
    {
        [HttpGet]
        public string Get() => "Hello, from the controller!";
    }
    ```

5. Run the app and you should be able to hit localhost:5000/api/articles.

## Returning JSON from the API

1. Create a folder called `Entities` and these classes:

    1. Add an  and an entity base interface called `IEntityBase`:

        ```
        namespace ConsoleApplication.Entities
        {
            public interface IEntityBase
            {
                int Id { get; set; }
            }
        }
        ```

    1. Then create a class called `Article`:

        ```C#
        public class Article : IEntityBase
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
        ```

  2. Add the `Microsoft.AspNetCore.Mvc.Formatters.Json` to `project.json`,

        `"Microsoft.AspNetCore.Mvc.Formatters.Json": "1.0.0"`    

  3. Configure MVC to use the JSON formatter by changing the `ConfigureServices` in `Startup.cs` to use the following,
    
```C#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvcCore().AddJsonFormatters();
    }
```

  4. Add a static list of projects to the `ArticlesController`:

  ```
    public class ArticlesController : Controller
    {
        private static List<Article> _Articles = new List<Article>(new[] {
            new Article() { Id = 1, Title = "Intro to ASP.NET Core" },
            new Article() { Id = 2, Title = "Docker Fundamentals" },
            new Article() { Id = 3, Title = "Deploying to Azure with Docker" },
        });
        ...
    }

  ```

  5. Change the `Get` method in `ArticlesController` to return `IEnumerable<Article>` and return the article with the id passed in.

```
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    OkOrNotFound(await _context.Articles.SingleOrDefaultAsync(a => a.Id == id));
}
```

  6. Run the application and navigate to `/api/articles/1`. You should see a JSON payload of that article.


When you are finished with this step, [continue to adding entity framework](https://github.com/Wyntuition/aspnetcore-workshop-kit/tree/master/03-EntityFramework)
