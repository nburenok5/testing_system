﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorApp3/BlazorApp3.csproj", "BlazorApp3/"]
RUN dotnet restore "BlazorApp3/BlazorApp3.csproj"
COPY . .
WORKDIR "/src/BlazorApp3"
RUN dotnet build "BlazorApp3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp3.dll"]
