## Create a .NET Core app, then set up ASP.NET 

This will create a basic .NET Core app using the .NET CLI, and then putting the core code needed to set up ASP.NET Core's dependencies and host initialization. 

1. Run ```dotnet new```, then ```dotnet run``` to create & run a .NET Core 'Hello World!' app. 
1. Add ASP.NET Core dependencies to project.json

    ```
    "dependencies": {

        "Microsoft.NETCore.App": {
            "version": "1.0.0",
            "type": "platform"
        },
        "Microsoft.AspNetCore.Server.Kestrel": "1.0.0"
    
    }
    ```

1. Add ASP.NET Core setup code to the Main method (entry point of all .NET Core applications, including ASP.NET Core) in Program.cs

    ```
    // Minimal ASP.NET setup in Main method

    var host = new WebHostBuilder()
        .UseKestrel()
        .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World!")))
        .Build();

    host.Run();


    // NOTE, these are needed, and can be added manually, or by the IDE 
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Hosting;
    ```

At this point, you have a minimal ASP.NET Core app set up.

1. Move configuration of the host to the Startup class, per convention. 

    a. Tweak your Program.cs to use a Startup class for ASP.NET Core host configuration:

    ```
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    //REMOVE THIS: .Configure(app => app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!")))
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()

                    .Build();

                host.Run();
            }
        }
    }

    ```

    a. Create a class in the project root called Startup.cs
    a. Add this to your Startup.cs class: 

    ```
    namespace ConsoleApplication
    {
        public class Startup
        {
            // This method gets called by the runtime, and is optional. Use this method to add services to the container.
            // IServiceCollection is a container of service contracts, allowing their injection and setup here (I.E. MVC, Entity Framework). If you add a service that requires substantial setup, wrap it in an extension method of this collection.
            // Services available at startup: https://docs.asp.net/en/latest/fundamentals/startup.html#services-available-in-startup
            public void ConfigureServices(IServiceCollection services)
            {
                // services.AddMvc();
            }

            // This method gets called by the runtime, after ConfigureServices, and is required. Use this method to configure the HTTP request pipeline.
            // IApplicationBuilder is required; provides the mechanisms to configure an application’s request pipeline.
            public void Configure(IApplicationBuilder app)
            {
                app.Run(context => context.Response.WriteAsync("Hello World, from ASP.NET!"));
            }
        }
    }
    ```

1. End up where you would be in creating an app from an ASP.NET Core template.