FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Backend.API/Backend.API.csproj", "Backend.API/"]
COPY ["./Backend.Contracts/Backend.Contracts.csproj", "Backend.Contracts/"]
COPY ["./Backend.Models/Backend.Models.csproj", "Backend.Models/"]
COPY ["./Backend.Repository/Backend.Repository.csproj", "Backend.Repository/"]

RUN dotnet restore "Backend.API/Backend.API.csproj"

COPY . .
RUN dotnet build "./Backend.API/Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Backend.API/Backend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.API.dll"]
