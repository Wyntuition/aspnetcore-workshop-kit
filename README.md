# Workshop: ASP.NET Core

This workshop goes through creating an ASP.NET Core application from scratch, so it is easier to see what all the parts are and what they do. We will use the new, platform-agnostic tools - the .NET Core CLI and VS Code so we can see the cross-platform experience. This can be conducted as a group workshop, or done individually. 

First, there will be an overview presentation of .NET Core, and then the architecture of ASP.NET Core. (Workshop presenters: there is a slide deck included).  

Then it goes walks through coding up a basic, API-based app, in order to understand the technology and the new development process. If there is time, we can deploy to the cloud, or even build a container and deploy it in that.

I recommend using Docker for the .NET Core development environment so you can build and run the app in a container. This way, you'll get to try the ASP.NET Core development workflow with Docker. You can skip using Docker if you'd like; you'll still be fine if your .NET Core SDK is working and the latest version, and there is nothing specific to Docker in these app building instructions. The operations are practically the same no matter which approach you are using. You can use this [Docker image of an ASP.NET Core development environmnet](https://hub.docker.com/r/wyntuition/aspnetcore-development-env/), and there are instructions for starting the container.

When finished, you should have a general understanding of .NET Core, ASP.NET Core and how to build basic ASP.NET Core apps.

## Prerequsites
Please install & verify you have correct versions installed:

* [Docker](https://www.docker.com/products/overview) (OS X, Windows, Linux, 1.12.1). Verify version: docker -v

* [.NET Core SDK](https://www.microsoft.com/net/core) (OS X, Windows, Linux, v 1.0.0-preview2-003121). Verify version: dotnet -v

* [VS Code](https://code.visualstudio.com/download) (OS X, Windows, Linux)

## Getting Started 

Start with [Create a .NET Core app and set up ASP.NET](00-BasicAspNetCoreApp), and follow the instructions. You don't need to clone the 'start' project - the first step is from scratch and the next steps build on each other, but you can clone in subsequent steps if you don't make it that far. The 'end' folders have the completed application for that section.

## Containers (optional)

If you're interested in using containers in the development process, take a look at these [instructions](MISC-Containers/README.md). It goes through running and building (optional) a container to build and run your ASP.NET Core app. It includes a Docker Hub image you can use, and instructions and a Dockerfile if you want to build your own.

When you're finished with the workshop, check out some [next steps](Next.md).

## [Get started now!](00-BasicAspNetCoreApp)