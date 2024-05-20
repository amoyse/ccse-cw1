# Use the official ASP.NET Core image with the .NET 6 SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY PacificTours/*.csproj ./PacificTours/
COPY Server/*.csproj ./PacificTours.Server/
COPY Client/*.csproj ./PacificTours.Client/
COPY Shared/*.csproj ./PacificTours.Shared/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PacificTours.Server.dll"]

