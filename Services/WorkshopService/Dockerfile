#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0.100-preview.7 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/nightly/sdk:8.0.100-preview.7 AS build
WORKDIR /src
COPY ["Services/WorkshopService/WorkshopService.csproj", "Services/WorkshopService/"]
RUN dotnet restore "Services/WorkshopService/WorkshopService.csproj"
COPY . .
WORKDIR "/src/Services/WorkshopService"
RUN dotnet build "WorkshopService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkshopService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkshopService.dll"]