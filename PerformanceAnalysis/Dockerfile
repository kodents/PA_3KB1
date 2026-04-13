# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["PerformanceAnalysis/PerformanceAnalysis.csproj", "PerformanceAnalysis/"]
RUN dotnet restore "PerformanceAnalysis/PerformanceAnalysis.csproj"

# Copy everything else and build
COPY PerformanceAnalysis/ PerformanceAnalysis/
WORKDIR "/src/PerformanceAnalysis"
RUN dotnet build "PerformanceAnalysis.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "PerformanceAnalysis.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PerformanceAnalysis.dll"]

