# Running in a Docker container 

## Build & run the container 

Take a look at the Dockerfile in the root's code in this section. This specifies what the container will have, and in this case, based on the latest public .NET Core image.

Then it adds some configuration for ASP.NET.  

You can build the ASP.NET Core container from your root app folder which will use the existing Dockerfile, using this command: 
  ```docker build -t <yourTag:YourAspNetImageName> .```

### Run the container 

- You can run the container, specifying a port binding for listening, the current app folder to mount in the container, and the image name, using this command:

    `docker run -d -p 8080:5000 -v $(pwd):/app -t <yourTag:YourAspNetImageName>`  

    EXAMPLE: [Run a container with an ASP.NET Core devlopment environmnet](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/) from a pre-made images from Docker Hub by running this:
    ```
    docker run -d -p 5000:5000 -v $(pwd):/app -t wyntuition/aspnetcore-development-env
    ```

    For more information about a Docker devlopment environmnet for ASP.NET Core, see [this Docker Hub image](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/).

Check out the [instructions on how to spin up multiple containers with docker-compose](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/). In this example, a postgreSQL container spins up in addition to an ASP.NET container.
