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

2. Add ASP.NET Core setup code to the Main method (entry point of all .NET Core applications, including ASP.NET Core) in Program.cs

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

3. Move configuration of the host to the Startup class, per convention. 

4. End up where you would be in creating an app from an ASP.NET Core template.