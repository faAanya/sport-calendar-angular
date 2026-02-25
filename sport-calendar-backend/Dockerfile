FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["sport-calendar.api/sport-calendar.api.csproj", "sport-calendar.api/"]
COPY ["sport-calendar.dal/sport-calendar.dal.csproj", "sport-calendar.dal/"]
COPY ["sport-calendar.il/sport-calendar.il.csproj", "sport-calendar.il/"]

RUN dotnet restore "sport-calendar.api/sport-calendar.api.csproj"

COPY . .
WORKDIR "/src/sport-calendar.api"
RUN dotnet build "sport-calendar.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sport-calendar.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sport-calendar.api.dll"]