# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 51

# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "MultiInstanceWebApp.csproj"
RUN dotnet build "MultiInstanceWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MultiInstanceWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MultiInstanceWebApp.dll"]