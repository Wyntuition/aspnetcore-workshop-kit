## Create a Web API app 

Set up the pieces to set up an API 

1. Set up MVC! The Web API has been merged into MVC, so it's all one package. 

    ```
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }
    ```