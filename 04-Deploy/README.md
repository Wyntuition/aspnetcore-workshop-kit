# Step 5: Deploying an ASP.NET Core app

## Publishing - preparing for deployment

1. Build using release mode:
```dotnet build -c release```

1. Publish the application - this basically compiles the app's files into an output target, for copying onto a server
```dotnet publish -c release -o app```

  We're specifying the output directory as 'app' here. This essentially made a folder, app, with the needed files, ready to be run. 

## Deployment

There are many options for deploying the package (/app) you now have. It's currently possible to deploy to Azure App Services very easily via local git repo. You can deploy in a container(s) to AWS Container Service very quickly. You can try in a container to Heroku, though they also support .NET Core directly in theory with its build pack (I haven't tried). 

For now we're going to show one of the easiest and fastest ways to deploy - to Azure App Services via a local git repo. 

# From Local Repo

1. Create a new Web App in Azure. Select 'Deployment Options' and Local Git as the source.
Go back to the app's properties and copy the Git URL listed. Create 'Deployment Credentials' to deploy here from git.

2. Create a local git repo, and set the remote push repo to the above Azure app git URL,
`git remote add azure <Azure app Git URL>`

Then commit and and push to Azure, `git push -u azure master`. For more [detailed instruction, see Microsoft's docs](https://azure.microsoft.com/en-us/documentation/articles/app-service-deploy-local-git/).

Congratulations! You have completed a basic ASP.NET Core Web API app, and gone through key steps involved in the lifecycle. Check out some [next steps and resources](https://github.com/excellalabs/aspnetcore-workshop-kit/blob/master/Next.md). 
