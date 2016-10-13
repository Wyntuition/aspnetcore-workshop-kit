# Running in a Docker container 

## Build the container (optional, you can skip to running the container to just get an environment started up)

Take a look at the Dockerfile in the root's code in this section. This specifies what the container will have, and in this case, it's based on the latest public .NET Core image. Then it adds some configuration for ASP.NET. You can build the ASP.NET Core container from the provided Dockerfile, following these steps: 

1. Run ```docker build -t <yourTag:YourAspNetImageName> .```

2. See that your image was created correct from the build step above, by listing the images on your machine, by typing `docker images`. You should see it in the list.

Then you can create new containers based off this image, which we'll do in the next step. Note, your application code will be in this container. 

For instructions on how to quickly get started with Docker if you don't have it installed and haven't used it, take a look at this article, [Getting Started with DOcker and .NET Core on OS X](https://www.excella.com/insights/getting-started-with-docker-and-net-core-on-os-x).

## Run the container 

You can have your ASP.NET Core environment in a Docker container while you develop on your host machine. Here is [an existing ASP.NET Core development environment Docker image](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/) which you can immediate run containers from.

For now, you can run the container you built or the one [mentioned on Docker Hub](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/), specifying a port binding for listening, the current app folder to mount in the container, and the image name, using the following command. 

1. Go to your ASP.NET Core app's directory (or an empty directory for a new app)

  ```
  docker run -d -p 8080:5000 -v $(pwd):/app -t <yourTag:YourAspNetImageName>
  ```  

2. You could also just run [a pre-made ASP.NET image from Docker Hub](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/) with this command:
    
  ```
  docker run -d -p 5000:5000 -v $(pwd):/app -t wyntuition/aspnetcore-development-env
  ```

Now you can code in your host environment using your IDE as usual, and the container will receive any file changes since your application directory is mounted into the container. 

## Docker Compose 

You can use Docker Compose to spin up multiple containers at once, in order to create a multi-server environmnet. The most common example would be to spin up a container running the application, and a container running the database. 

There is a `docker-compose.yml` file in the repo that use Docker Compose to spin up an ASP.NET Core container, and a postgreSQL container.

### To build the images and run them:

  ```
  docker-compose up
  ```

You can add -d at the end so the containers run in the background; without it they would stop when you exit the shell. You can connect to the shell via 'docker exec -ti <Container> sh`.

### To stop the containers:

  ```
  docker-compose stop
  ```

With them running, you should be able to navigate to your web app (or the Web API sample endpoint in this app - http://localhost:8080/api/articles). You should be able to develop as usual on your computer, but when you save, your code is rebuilt in the ASP.NET container, and then run from there. You can try changing the /Controllers/ArticlesController.cs code and see it update at that endpoint, which is being hosted from the ASP.NET container.

It is useful to log into your containers. To do that, use this: 

  ```
  docker exec -ti <Container name> sh
  ```