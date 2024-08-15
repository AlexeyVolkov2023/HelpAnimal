FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/HelpAnimal.API/HelpAnimal.API.csproj", "src/HelpAnimal.API/"]
COPY ["src/HelpAnimal.Application/HelpAnimal.Application.csproj", "src/HelpAnimal.Application/"]
COPY ["src/HelpAnimal.Domain/HelpAnimal.Domain.csproj", "src/HelpAnimal.Domain/"]
COPY ["src/HelpAnimal.Infrastructura/HelpAnimal.Infrastructura.csproj", "src/HelpAnimal.Infrastructura/"]
RUN dotnet restore "src/HelpAnimal.API/HelpAnimal.API.csproj"
COPY . .
WORKDIR "/src/src/HelpAnimal.API"
RUN dotnet build "HelpAnimal.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HelpAnimal.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelpAnimal.API.dll"]
