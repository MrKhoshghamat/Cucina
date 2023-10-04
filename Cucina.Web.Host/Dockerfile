FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Cucina.Web.Host/Cucina.Web.Host.csproj", "Cucina.Web.Host/"]
RUN dotnet restore "Cucina.Web.Host/Cucina.Web.Host.csproj"
COPY . .
WORKDIR "/src/Cucina.Web.Host"
RUN dotnet build "Cucina.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cucina.Web.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cucina.Web.Host.dll"]
