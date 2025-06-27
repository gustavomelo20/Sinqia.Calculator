FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Sinqia.Calculator.Api/Sinqia.Calculator.Api.csproj", "src/Sinqia.Calculator.Api/"]
COPY ["src/Sinqia.Calculator.Application/Sinqia.Calculator.Application.csproj", "src/Sinqia.Calculator.Application/"]
COPY ["src/Sinqia.Calculator.Domain/Sinqia.Calculator.Domain.csproj", "src/Sinqia.Calculator.Domain/"]
COPY ["src/Sinqia.Calculator.Infrastructure/Sinqia.Calculator.Infrastructure.csproj", "src/Sinqia.Calculator.Infrastructure/"]
RUN dotnet restore "src/Sinqia.Calculator.Api/Sinqia.Calculator.Api.csproj"
COPY . .
WORKDIR "/src/src/Sinqia.Calculator.Api"
RUN dotnet build "./Sinqia.Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Sinqia.Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sinqia.Calculator.Api.dll"]
