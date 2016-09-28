# Step 2: Configuring basic app features

## Objectives
- Set up configuration files
- Set up environment-specific settings
- Logging
- Dependency injection

## Hosting environment 

There are a number of things we want happening differently depending what hosting environment we're in, such as showing exceptions in the browser if we're in our development environment or using a specific configuration file per environment. If we don't specify somehow, ASP.NET will default to our hosting environment being "Production". There are a number of ways to set the hosting environment. 

1. We're going to set the hosting environment to "Development" in our OS's environment variables, so it will default to that. Otherwise you'd have to pass a an argument, when running the app from the command line, to set it to that (you can also set it in Visual Studio and VS Code, see the below blog). 

    See [this blog](http://andrewlock.net/how-to-set-the-hosting-environment-in-asp-net-core/) for how to set the environment variable on your OS. For OS X, run this in your bash,

    ```
    sudo nano ~/.bash_profile
    ```

    Add this, and hit Ctrl+X to save and exit: 

    ```
    export ASPNETCORE_ENVIRONMENT=Development 
    ```  

2. Run `dotnet run` and see that it says the hosting environment is now development. 

3. Now we want to set it up so when the hosting environment is development, it will display a detailed exception page in the browser, including header information. 

    1. To do that, first add this dependency: 

        ```
        "Microsoft.AspNetCore.Diagnostics": "1.0.0",
        ```

    1. Then add  `IHostingEnvironment` to the Startup.cs `Configure` method, and use that object to get the environment. Then add the code to check the environment and add the developer exception page middleware:

        ```
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ...
        ```

    1. You can test it and see the exception page by creating an exception in the pipeline, right under the UseDeveloperExceptionPage:  
        ```
        app.Run((context) =>
        {
            throw new InvalidOperationException("Oops!");
        });
        ```
    1. Run and browse to the app. You should see the detailed exception page. Otherwise, nothing would be displayed with the 500 response. Remove the exception just added. 

## Command-line arguments

We're going to need to change the hosting environment locally sometimes. For example, we might want run the Production configuration settings locally while we're developing them. To allow this, we're going to add functionality to pass command-line arguments into our app. 

1. Add this configuration Program.cs's Main method. You will need to add a using statement:

    ```
    var config = new ConfigurationBuilder()  
        .AddCommandLine(args)
        .Build();
    ```

2. Then add this right before Build() in the WebHostBuilder initialization, so we can use the configuration object we just created: 

    ```
    .UseConfiguration(config)
    ```

    Now you can run `dotnet run --environment "production"` when you want the hosting environment to be that (or you can use staging, etc or your own). 

## Configuration files

Key configuration files in ASP.NET Core include appSettings.json. We're going to add that now, as well as a version for production.

In order to read that and other configuration sources, we have to:

1. Add these dependencies:

    ```
    "Microsoft.Extensions.Configuration.CommandLine": "1.0.0",
    "Microsoft.Extensions.Configuration.FileExtensions": "1.0.0-*",
    "Microsoft.Extensions.Configuration.Json": "1.0.0"
    ```

1. Add this to Startup:

    ```
    public IConfigurationRoot Configuration { get; }
    ...

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder() // Collection of sources for read/write key/value pairs
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables(); // Overrides environment variables with valiues from config files/etc
      Configuration = builder.Build();
    }
    ```

2. Add a new file in the root called `appSettings.json` with this:

    ```
    {
      "Logging": {
        "IncludeScopes": false,
        "LogLevel": {
          "Default": "Debug",
          "System": "Information",
          "Microsoft": "Information"
        }
      }
    }
    ```

3. Add an `appSettings.Production.json` file with the same contents from above, but change the `Default` value to `Information`.

    We'll use the appSettings later.

## Logging

1. Add the `Microsoft.Extensions.Logging.Console` package to `project.json`:

    ```
    "Microsoft.Extensions.Logging.Console": "1.0.0"
    ```

2. Navigate to `Startup.cs` and change the `Configure` method to:

    ```C#
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));

        var startupLogger = loggerFactory.CreateLogger<Startup>();
        ...
    ```

3. Add some log statements to the end of the `Configure` method to test the settings:

    ```C#
    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
      ...
        startupLogger.LogTrace("Trace test output!");
        startupLogger.LogDebug("Debug test output!");
        startupLogger.LogInformation("Info test output!");            
        startupLogger.LogError("Error test output!");
        startupLogger.LogCritical("Trace test output!");
    }
    ```

4. Run `dotnet restore` since we added a package, and then `dotnet run`. In the console, you should see the all the log statements you just added since in `appSettings.json` it is set to show debug log entries and more severe.

5. Run `dotnet run --environment "Production"` 

    You should no longer see the debug log entry in the console, since the `appSettings.Production.json` is set to only show informational log entries and more severe. Also note that it says the hosting environment in the console, which should be "production". 

## Dependency Injection

Here are some key points about the dependency injection that is now baked into ASP.NET Core: 

- ASP.NET Core includes a simple built-in container *represented by the IServiceProvider interface* that supports constructor injection by default, and ASP.NET makes certain services available through DI.
- ASP.NET’s container refers to the types it manages as services.
- You configure the built-in container’s services in the ConfigureServices method in your application’s Startup class.
- The built-in services container is meant to serve the basic needs of the framework and most consumer applications built on it, but has a minimal feature set and is not intended to replace other containers.

When you are finished with this step, [continue to adding entity framework](https://github.com/Wyntuition/aspnetcore-workshop-kit/tree/master/03-EntityFramework)
