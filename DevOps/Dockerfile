# Verwende das offizielle ASP.NET Core Runtime-Image für x64-Architektur
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Verwende das offizielle .NET SDK-Image zum Bauen der Anwendung
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopiere die Projektdatei und führe den Wiederherstellungsbefehl aus
COPY DevOps.csproj ./
RUN dotnet restore

# Kopiere alle Dateien und Verzeichnisse und baue die Anwendung
COPY . ./
RUN dotnet build -c Release -o /app/build

# Veröffentliche die Anwendung
RUN dotnet publish -c Release -o /app/publish

# Führe die Anwendung im finalen Image aus
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DevOps.dll"]
