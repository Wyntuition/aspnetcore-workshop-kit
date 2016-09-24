# Deploying an ASP.NET Core app

## Azure

# From Local Repo

1. Create a new Web App in Azure. Select 'Deployment Options' and Local Git as the source.
Go back to the app's properties and copy the Git URL listed. Create 'Deployment Credentials' to deploy here from git.

2. Create a local git repo, and set the remote push repo to the above Azure app git URL,
`git remote add azure <Azure app Git URL>`

Then commit and and push to Azure, `git push -u azure master`



## Deploying ASP.NET Core app

1. Build using release mode:
```dotnet build -c release```

1. Publish the application - this basically compiles the app's files into an output target, for copying onto a server
```dotnet publish -c release -o app```

  We're specifying the output directory as 'app' here.

1. There are many options for deploying the package you now have.
  - It's currently possible to deploy to Azure App Services very easily via local git repo.
  - You can try to deploy in a container(s) to AWS Container Service or Heroku
