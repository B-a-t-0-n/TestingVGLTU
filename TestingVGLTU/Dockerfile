# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestingVGLTU/TestingVGLTU.csproj", "TestingVGLTU/"]
COPY ["Accounts/TestingVGLTU.Accounts.Presentation/TestingVGLTU.Accounts.Presentation.csproj", "Accounts/TestingVGLTU.Accounts.Presentation/"]
COPY ["Shared/TestingVGLTU.Framework/TestingVGLTU.Framework.csproj", "Shared/TestingVGLTU.Framework/"]
COPY ["Shared/TestingVGLTU.Core/TestingVGLTU.Core.csproj", "Shared/TestingVGLTU.Core/"]
COPY ["Shared/TestingVGLTU.SharedKernel/TestingVGLTU.SharedKernel.csproj", "Shared/TestingVGLTU.SharedKernel/"]
COPY ["Accounts/TestingVGLTU.Accounts.Application/TestingVGLTU.Accounts.Application.csproj", "Accounts/TestingVGLTU.Accounts.Application/"]
COPY ["Accounts/TestingVGLTU.Accounts.Domain/TestingVGLTU.Accounts.Domain.csproj", "Accounts/TestingVGLTU.Accounts.Domain/"]
COPY ["Accounts/TestingVGLTU.Accounts.Contracts/TestingVGLTU.Accounts.Contracts.csproj", "Accounts/TestingVGLTU.Accounts.Contracts/"]
COPY ["ActiveTestings/TestingVGLTU.ActiveTestings.Presentation/TestingVGLTU.ActiveTestings.Presentation.csproj", "ActiveTestings/TestingVGLTU.ActiveTestings.Presentation/"]
COPY ["ActiveTestings/TestingVGLTU.ActiveTestings.Application/TestingVGLTU.ActiveTestings.Application.csproj", "ActiveTestings/TestingVGLTU.ActiveTestings.Application/"]
COPY ["ActiveTestings/TestingVGLTU.ActiveTestings.Domain/TestingVGLTU.ActiveTestings.Domain.csproj", "ActiveTestings/TestingVGLTU.ActiveTestings.Domain/"]
COPY ["ActiveTestings/TestingVGLTU.ActiveTestings.Contracts/TestingVGLTU.ActiveTestings.Contracts.csproj", "ActiveTestings/TestingVGLTU.ActiveTestings.Contracts/"]
COPY ["LayoutTestings/TestingVGLTU.LayoutTestings.Presentation/TestingVGLTU.LayoutTestings.Presentation.csproj", "LayoutTestings/TestingVGLTU.LayoutTestings.Presentation/"]
COPY ["LayoutTestings/TestingVGLTU.LayoutTestings.Application/TestingVGLTU.LayoutTestings.Application.csproj", "LayoutTestings/TestingVGLTU.LayoutTestings.Application/"]
COPY ["LayoutTestings/TestingVGLTU.LayoutTestings.Domain/TestingVGLTU.LayoutTestings.Domain.csproj", "LayoutTestings/TestingVGLTU.LayoutTestings.Domain/"]
COPY ["LayoutTestings/TestingVGLTU.LayoutTestings.Contracts/TestingVGLTU.LayoutTestings.Contracts.csproj", "LayoutTestings/TestingVGLTU.LayoutTestings.Contracts/"]
COPY ["TestingVGLTU.Infrastructure/TestingVGLTU.Infrastructure.csproj", "TestingVGLTU.Infrastructure/"]
RUN dotnet restore "./TestingVGLTU/TestingVGLTU.csproj"
COPY . .
WORKDIR "/src/TestingVGLTU"
RUN dotnet build "./TestingVGLTU.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestingVGLTU.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestingVGLTU.dll"]