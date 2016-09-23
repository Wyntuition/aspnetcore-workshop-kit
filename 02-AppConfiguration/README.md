# Configuring basic app features

## Objectives
- Set up configuration files
- Set up environment-specific settings
- Logging and Diagnostics
- Dependency injection

## Configuration files

1. Key configuration files in ASP.NET include appSettings.json. In order to read that and other configuration sources, we have to add this to our Startup:

    ```
    public IConfigurationRoot Configuration { get; }
    ...

    var builder = new ConfigurationBuilder() // Collection of sources for read/write key/value pairs
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
    Configuration = builder.Build();
    ```

2. Add a new file in the root called `app.settings` with this:

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

## Logging and Diagnostics

Please see [the Logging and Diagnostics section in Damian Edwards' workshop](https://github.com/DamianEdwards/aspnetcore-workshop/blob/master/Labs/4.%20Logging%20and%20Diagnostics.md).

Add the `Microsoft.Extensions.Logging.Console` package to `project.json` and save your changes:

    ```
    JSON
      "dependencies": {
        "Microsoft.Extensions.Logging.Console": "1.0.0-rc2-final"
      },
    ```

  3. Navigate to `Startup.cs` and change the `Configure` method to:

      ```C#
          public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
          {
              loggerFactory.AddConsole();

              var startupLogger = loggerFactory.CreateLogger<Startup>();
              ...
          }
      ```

    4. Add a log statement to the end of the `Configure` method:

    ```C#
          public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
          {
              ...
              startupLogger.LogInformation("Application startup complete!");
          }
          ```


          # Diagnostic pages

          ## Write some buggy code

          1. Add a middleware to the above application that throws an exception. Your `Configure` method should look something like this:

              ```C#
              public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
              {
                  loggerFactory.AddConsole();

                  loggerFactory.AddSerilog();

                  ...

                  app.Run((context) =>
                  {
                      throw new InvalidOperationException("Oops!");
                  });

                  ...
              }
              ```
          2. Run the application and open a browser window with `http://localhost:5000/` as the address. The debugger will break at the `   `InvalidOperationException`. If you type `F5` again to continue, you should see a generic browser error page but the exception message should appear in the console.

          ## Adding the diagnostics middleware

          1. Add the `Microsoft.AspNetCore.Diagnostics` to `project.json`:

              ```JSON
                "dependencies": {
                  "Microsoft.AspNetCore.Diagnostics": "1.0.0-rc2-final",
                  "Microsoft.AspNetCore.Server.Kestrel": "1.0.0-rc2-final",
                  "Microsoft.Extensions.Logging.Console": "1.0.0-rc2-final",
                  "Serilog.Extensions.Logging": "1.0.0-rc2-10110",
                  "Serilog.Sinks.File": "2.0.0-rc-706"
                },
              ```

          2. Add the developer experience middleware before the middleware that throws the exception:

              ```C#
              app.UseDeveloperExceptionPage();

              app.Run((context) =>
              {
                  throw new InvalidOperationException("Oops!");
              });
              ```
          3. Run the application and open a browser window with `http://localhost:5000/` as the address. The debugger will break at the `   `InvalidOperationException`. If you type `F5` again to continue, you should see an application exception page in the browser.

          ## Only showing exception pages during development

          1. Change the Configure method signature to take `IHostingEnvironment`:

              ```C#
              public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
              ```

          2. Add the exception handler middleware to the `Configure` method. Make sure it only runs when not in development:

              ```C#
              if (env.IsDevelopment())
              {
                  app.UseDeveloperExceptionPage();
              }
              else
              {
                  app.UseExceptionHandler(subApp =>
                  {
                      subApp.Run(async context =>
                      {
                          context.Response.ContentType = "text/html";
                          await context.Response.WriteAsync("<strong> Oops! Something went wrong :( </strong>");
                          await context.Response.WriteAsync(new string(' ', 512));  // Padding for IE
                      });
                  });
              }
              ```

          3. Run the application in "Production" and open a browser window with `http://localhost:5000/` as the address. Type `F5` at the exception and you should see the custom error page instead of the exception.

          ## Showing custom pages for non 500 status codes

          1. Change the middleware throwing the exception message to instead set a 404 status code:

              ```C#
              app.Run((context) =>
              {
                  context.Response.StatusCode = 404;
                  return Task.FromResult(0);
              });
              ```
          2. Add the status code pages middleware above the exception handler middleware in `Configure`:

              ```C#
              app.UseStatusCodePages(subApp =>
              {
                  subApp.Run(async context =>
                  {
                      context.Response.ContentType = "text/html";
                      await context.Response.WriteAsync($"<strong> You got a {context.Response.StatusCode}<strong>");
                      await context.Response.WriteAsync(new string(' ', 512));  // Padding for IE
                  });
              });

              ...
              ```
          3. Run the application and open a browser window with `http://localhost:5000/` as the address. You should see the custom error page instead of the browser's default 404 page.



## Dependency Injection

- ASP.NET Core includes a simple built-in container *represented by the IServiceProvider interface* that supports constructor injection by default, and ASP.NET makes certain services available through DI.
- ASP.NET’s container refers to the types it manages as services.
- You configure the built-in container’s services in the ConfigureServices method in your application’s Startup class.
- The built-in services container is meant to serve the basic needs of the framework and most consumer applications built on it, but has a minimal feature set and is not intended to replace other containers.

When you are finished with this step, [continue to adding entity framework](https://github.com/Wyntuition/aspnetcore-workshop-kit/tree/master/03-EntityFramework)
