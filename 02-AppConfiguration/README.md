# Configuring basic app features 

## Objectives 
- Set up configuration files 
- Set up environment-specific settings
- Logging and Diagnostics, https://github.com/DamianEdwards/aspnetcore-workshop/blob/master/Labs/4.%20Logging%20and%20Diagnostics.md
- Dependency injection 

## Configuration files 

Key configuration files in ASP.NET include appSettings.json. In order to read that and other configuration sources, we have to add this to our Startup:

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

### app.settings 

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

When you are finished with this step, [continue to adding entity framework](https://github.com/Wyntuition/aspnetcore-workshop-kit/tree/master/03-EntityFramework)
