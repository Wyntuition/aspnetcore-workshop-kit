## Creating a .NET Core app, then setting up ASP.NET 

This will create a basic .NET Core app using the .NET CLI, and then putting the core code needed to set up ASP.NET Core's dependencies and initialization. 

1. Run ```dotnet new```, then ```dotnet run``` 
1. Add ASP.NET Core dependencies to project.json
2. Add ASP.NET Core setup code to the Main method (entry point of all .NET Core applications, including ASP.NET Core) in Program.cs