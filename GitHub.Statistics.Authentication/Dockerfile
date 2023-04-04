#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5502
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GitHub.Statistics.Authentication.csproj", "auth/"]
RUN dotnet restore "auth/GitHub.Statistics.Authentication.csproj"

WORKDIR "/src/auth"
COPY . .

RUN dotnet build "GitHub.Statistics.Authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitHub.Statistics.Authentication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitHub.Statistics.Authentication.dll"]