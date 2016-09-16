## Create a Web API app 

Set up the pieces to set up an API 

1. Set up MVC! The Web API has been merged into MVC, so it's all one package. 

Add this method to the Startup class: 

```
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvcCore();
}
```

Add this line to the Configure method in Startup:

```
app.UseMvc();
```

And add this dependency for MVC, 

```
"Microsoft.AspNetCore.Mvc": "1.0.0"
```

1. Add meaningful web components - appsettings, web.config

1. Add a controller to serve the API requests called `ArticlesController` and add the following. 

```
[Route("/api/[controller]")]
public class ArticlesController
{
  [HttpGet]
  public string Get() => "Hello World";
}
```

Run the app and you should be able to hit localhost:5000/api/articles. 

