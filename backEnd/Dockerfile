# -------- STAGE 1 : build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copier la solution
COPY backEnd/Kolyya.sln ./

# Copier le projet API
COPY backEnd/Kolyya.Api/Kolyya.Api.csproj ./Kolyya.Api/

# Restaurer les dépendances
RUN dotnet restore

# Copier le reste du code
COPY backEnd/Kolyya.Api/. ./Kolyya.Api/

# Publier l'application
WORKDIR /app/Kolyya.Api
RUN dotnet publish -c Release -o /app/publish

# -------- STAGE 2 : runtime --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "Kolyya.Api.dll"]
