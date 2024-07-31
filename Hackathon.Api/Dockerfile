FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

RUN apt-get update && \
    apt-get install -y unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | sh /dev/stdin -v latest -l /remote_debugger

USER app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Hackathon.Api/Hackathon.Api.csproj", "Hackathon.Api/"]
COPY ["Hackathon.Infra.Data/Hackathon.Infra.Data.csproj", "Hackathon.Infra.Data/"]
RUN dotnet restore "./Hackathon.Api/Hackathon.Api.csproj"
COPY . .
WORKDIR "/src/Hackathon.Api"
RUN dotnet build "./Hackathon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Hackathon.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet tool install --global dotnet-ef --version 7.0.2

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER root

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update --project ../Hackathon.Infra.Data --startup-project .

ENTRYPOINT ["dotnet", "Hackathon.Api.dll"]