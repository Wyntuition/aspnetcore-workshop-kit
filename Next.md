# Deploying ASP.NET Core app

1. Build using release mode:
```dotnet build -c release```

1. Publish the application - this basically compiles the app's files into an output target, for copying onto a server
```dotnet publish -c release -o app```

We're specifying the output directory as 'app' here.

# Resources

- [ASP.NET Core Docs](https://docs.asp.net/en/latest/intro.html) are great!
- [Docker image of ASP.NET Core development environment](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/)
- [ASP.NET Core Workshop with other sections](https://github.com/DamianEdwards/aspnetcore-workshop/tree/master/Labs)
- [Getting Started with ASP.NET Core and Docker on OS X](https://www.excella.com/insights/getting-started-with-docker-and-net-core-on-os-x)
- [talks from dotnetConf 2016](https://channel9.msdn.com/Events/dotnetConf/2016)
