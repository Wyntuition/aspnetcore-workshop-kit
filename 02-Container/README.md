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

 You can build the container from this folder using this Dockerfile, using this command: 
```docker build -t mydemos:aspnetcorehelloworld .

You then run the container, specifying a port binding for listening, the current app folder to mount in the container, and the container tag.
```docker run -d -p 8080:5000 -v $(pwd):/app -t mydemos:aspnetcorehelloworld``` 
