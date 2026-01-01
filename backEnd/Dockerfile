# -------- STAGE 1 : build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier les fichiers projet et restaurer les dépendances
COPY *.sln .
COPY backEnd/*.csproj ./backEnd/
RUN dotnet restore

# Copier tout le code et compiler
COPY backEnd/. ./backEnd/
WORKDIR /app/backEnd
RUN dotnet publish -c Release -o /app/publish

# -------- STAGE 2 : runtime --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose le port utilisé par le backend
EXPOSE 5000

ENTRYPOINT ["dotnet", "backEnd.dll"]
