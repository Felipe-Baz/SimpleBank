FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["simplebank/simplebank.csproj", "simplebank/"]
RUN dotnet restore "simplebank/simplebank.csproj"
COPY . .
WORKDIR "/src/simplebank"
RUN dotnet build "simplebank.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "simplebank.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "simplebank.dll"]
