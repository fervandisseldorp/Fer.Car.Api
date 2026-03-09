# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore Fer.Car.Api/Fer.Car.Api.csproj
RUN dotnet publish Fer.Car.Api/Fer.Car.Api.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5249

ENTRYPOINT ["dotnet", "Fer.Car.Api.dll"]