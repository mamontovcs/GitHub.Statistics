#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GitHub.Statistics.API/GitHub.Statistics.API.csproj", "GitHub.Statistics.API/"]
COPY ["GitHub.Statistics.API/GitHub.Statistics.API.csproj", "GitHub.Statistics.API/"]
RUN dotnet restore "GitHub.Statistics.API/GitHub.Statistics.API.csproj"
COPY . .
WORKDIR "/src/GitHub.Statistics.API"
RUN dotnet build "GitHub.Statistics.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitHub.Statistics.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitHub.Statistics.API.dll"]