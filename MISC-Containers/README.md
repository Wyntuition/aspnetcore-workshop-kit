# Running in a Docker container 

## Watcher for changed files 

```
"tools": {
    "Microsoft.DotNet.Watcher.Tools": {
      "version": "1.0.0-*",
      "imports": "portable-net451+win8"
    }
  }
```

The `dotnet watch run` commend is in the Dockerfile so it will start when the container is started. 

## Build & run the container 

Take a look at the Dockerfile. This specifies what the container will have, and in this case, based on the latest public .NET Core image.

Then it adds some configuration for ASP.NET.  

You can build the ASP.NET Core container from your root app folder which will use the existing Dockerfile, using this command: 
 ```docker build -t <yourTag:YourAspNetImageName> .```

You can run the container, specifying a port binding for listening, the current app folder to mount in the container, and the image name, using this command:
```docker run -d -p 8080:5000 -v $(pwd):/app -t <yourTag:YourAspNetImageName>```

You could manually spin up the postgreSQL container or others in a similar manner. 