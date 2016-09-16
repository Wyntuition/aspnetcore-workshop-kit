# base
FROM microsoft/dotnet:latest
#FROM microsoft/dotnet:1.0.1-core # This is good for running the app, but no dev tools

# set up package cache
RUN curl -o /tmp/packagescache.tar.gz https://dist.asp.net/packagecache/aspnetcore.packagecache-1.0.1-debian.8-x64.tar.gz && \
    mkdir /packagescache && cd /packagescache && \
    tar xvf /tmp/packagescache.tar.gz && \
    rm /tmp/packagescache.tar.gz && \
    cd /

# set env var for packages cache
ENV DOTNET_HOSTING_OPTIMIZATION_CACHE /packagescache

# set up network
#ENV ASPNETCORE_URLS http://+:80
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
 
# copy my app from current directory
COPY . /app
WORKDIR /app
 
# good to use if running app, but not necessarily wanted for development environment 
#RUN ["dotnet", "restore"]
#RUN ["dotnet", "build"]
#ENTRYPOINT ["dotnet", "run"]

# REFERENCE: https://github.com/aspnet/aspnet-docker/blob/master/1.0.1/jessie/product/Dockerfile