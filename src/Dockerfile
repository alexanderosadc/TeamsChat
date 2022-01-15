# syntax=docker/dockerfile:1
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /.

# # Copy csproj and restore as distinct layers
# COPY /TeamsChat.WebApi/*.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# # COPY ../engine/examples ./
# # RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /.
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]


# #See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
# EXPOSE 44342
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TeamsChat.WebApi/TeamsChat.WebApi.csproj", "TeamsChat.WebApi/"]
COPY ["TeamsChat.TimeoutService/TeamsChat.TimeoutService.csproj", "TeamsChat.TimeoutService/"]
COPY ["TeamsChat.DataBaseFactory/TeamsChat.DatabaseInterface.csproj", "TeamsChat.DataBaseFactory/"]
COPY ["TeamsChat.MongoDbService/TeamsChat.MongoDbService.csproj", "TeamsChat.MongoDbService/"]
COPY ["TeamsChat.DataObjects/TeamsChat.DataObjects.csproj", "TeamsChat.DataObjects/"]
COPY ["TeamsChat.Data/TeamsChat.SSMSService.csproj", "TeamsChat.Data/"]
RUN dotnet restore "TeamsChat.WebApi/TeamsChat.WebApi.csproj"
COPY . .
WORKDIR "/src/TeamsChat.WebApi"
RUN dotnet build "TeamsChat.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamsChat.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamsChat.WebApi.dll"]