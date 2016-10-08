# base
FROM microsoft/dotnet:latest
#FROM microsoft/dotnet:1.0.1-core # This is good for deployed apps as it will be minimal 

# set up network
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

# copy my app from current directory to target on container 
COPY . /app 
WORKDIR /app
 
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
ENTRYPOINT ["dotnet", "watch", "run"]