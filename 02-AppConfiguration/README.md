# Configuring basic app features

## Objectives
- Set up configuration files
- Set up environment-specific settings
- Logging
- Dependency injection

## Configuration files

Key configuration files in ASP.NET include appSettings.json. In order to read that and other configuration sources, we have to

1. Add these dependencies, `"Microsoft.Extensions.Configuration.CommandLine": "1.0.0",
"Microsoft.Extensions.Configuration.FileExtensions": "1.0.0-*",
"Microsoft.Extensions.Configuration.Json": "1.0.0"`

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
        .AddEnvironmentVariables();
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
  public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
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
    startupLogger.LogDebug("Debug output!");
    startupLogger.LogInformation("Application startup complete!");
    startupLogger.LogTrace("Trace output!");
    startupLogger.LogError("Error output!");
  }
  ```

## Dependency Injection

- ASP.NET Core includes a simple built-in container *represented by the IServiceProvider interface* that supports constructor injection by default, and ASP.NET makes certain services available through DI.
- ASP.NET’s container refers to the types it manages as services.
- You configure the built-in container’s services in the ConfigureServices method in your application’s Startup class.
- The built-in services container is meant to serve the basic needs of the framework and most consumer applications built on it, but has a minimal feature set and is not intended to replace other containers.

When you are finished with this step, [continue to adding entity framework](https://github.com/Wyntuition/aspnetcore-workshop-kit/tree/master/03-EntityFramework)
