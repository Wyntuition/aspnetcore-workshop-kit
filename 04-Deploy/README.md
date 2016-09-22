# Deploying an ASP.NET Core app 

## Azure 

# From Local Repo

1. Create a new Web App in Azure. Select 'Deployment Options' and Local Git as the source. 
Go back to the app's properties and copy the Git URL listed. Create 'Deployment Credentials' to deploy here from git. 

2. Create a local git repo, and set the remote push repo to the above Azure app git URL, 
`git remote add azure <Azure app Git URL>`

Then commit and and push to Azure, `git push -u azure master` 

