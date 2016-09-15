## Create a Web API app 

Set up the pieces to set up an API 

1. Set up MVC! The Web API has been merged into MVC, so it's all one package. 

Add this method to the Startup class: 

    ````
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }
    ````

Add this line to the Configure method in Startup:
    ````
    app.UseMvc();
    ````

And add this dependency for MVC, 

    ````
    "Microsoft.AspNetCore.Mvc": "1.0.0"
    ````

2. Add meaningful web components - appsettings, web.config

3. Add model and controller 