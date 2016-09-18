# Deploying ASP.NET Core app 

1. Build using release mode: 
```dotnet build -c release```

1. Publish the application - this basically compiles the app's files into an output target, for copying onto a server 
```dotnet publish -c release -o app```

We're specifying the output directory as 'app' here. 