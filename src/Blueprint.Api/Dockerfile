#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Blueprint.Api/Blueprint.Api.csproj", "src/Blueprint.Api/"]
RUN dotnet restore "src/Blueprint.Api/Blueprint.Api.csproj"
COPY . .
WORKDIR "/src/src/Blueprint.Api"
RUN dotnet build "Blueprint.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blueprint.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blueprint.Api.dll"]