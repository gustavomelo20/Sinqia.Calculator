FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY src/Sinqia.Calculator.Domain ./Sinqia.Calculator.Domain
COPY src/Sinqia.Calculator.Application ./Sinqia.Calculator.Application
COPY src/Sinqia.Calculator.Infrastructure ./Sinqia.Calculator.Infrastructure
COPY src/Sinqia.Calculator.Api ./Sinqia.Calculator.Api

WORKDIR /app/Sinqia.Calculator.Api

RUN dotnet restore

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 80

ENTRYPOINT ["dotnet", "Sinqia.Calculator.Api.dll"]
