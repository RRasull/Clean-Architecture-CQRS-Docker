#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Clean-Architecture-CQRS-Docker/Clean-Architecture-CQRS-Docker.csproj", "Clean-Architecture-CQRS-Docker/"]
COPY ["Clean-Architecture-CQRS-Docker.Application/Clean-Architecture-CQRS-Docker.Application.csproj", "Clean-Architecture-CQRS-Docker.Application/"]
COPY ["Clean-Architecture-CQRS-Docker.Domain/Clean-Architecture-CQRS-Docker.Domain.csproj", "Clean-Architecture-CQRS-Docker.Domain/"]
COPY ["Clean-Architecture-CQRS-Docker.Infrastructure/Clean-Architecture-CQRS-Docker.Infrastructure.csproj", "Clean-Architecture-CQRS-Docker.Infrastructure/"]
RUN dotnet restore "Clean-Architecture-CQRS-Docker/Clean-Architecture-CQRS-Docker.csproj"
COPY . .
WORKDIR "/src/Clean-Architecture-CQRS-Docker"
RUN dotnet build "Clean-Architecture-CQRS-Docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clean-Architecture-CQRS-Docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clean-Architecture-CQRS-Docker.dll"]