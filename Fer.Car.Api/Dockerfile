# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first (for caching)
COPY Fer.Car.Api/Fer.Car.Api.csproj Fer.Car.Api/
COPY Fer.Car.Repository/Fer.Car.Repository.csproj Fer.Car.Repository/
COPY Fer.Car.Domain/Fer.Car.Domain.csproj Fer.Car.Domain/

# Restore dependencies
RUN dotnet restore Fer.Car.Api/Fer.Car.Api.csproj

# Copy the rest of the source code
COPY . .

# Publish application
RUN dotnet publish Fer.Car.Api/Fer.Car.Api.csproj -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Fer.Car.Api.dll"]