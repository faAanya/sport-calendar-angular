FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["sport-calendar-backend/sport-calendar-backend.csproj", "sport-calendar-backend/"]
RUN dotnet restore "sport-calendar-backend/sport-calendar-backend.csproj"
COPY . .
WORKDIR "/src/sport-calendar-backend"
RUN dotnet build "./sport-calendar-backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./sport-calendar-backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sport-calendar-backend.dll"]
