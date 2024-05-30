FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AppFrontend/AppFrontend.csproj", "AppFrontend/"]
COPY ["backend/TaskService/TaskService.csproj", "backend/TaskService/"]
COPY ["TaskFramework/TaskFramework.csproj", "TaskFramework/"]
RUN dotnet restore "AppFrontend/AppFrontend.csproj"
COPY . .
WORKDIR "/src/AppFrontend"
RUN dotnet build "AppFrontend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AppFrontend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppFrontend.dll"]
