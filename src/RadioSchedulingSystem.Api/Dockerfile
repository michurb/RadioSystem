FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .

COPY src/RadioSchedulingSystem.Infrastructure/*.csproj ./src/RadioSchedulingSystem.Infrastructure/
COPY src/RadioSchedulingSystem.Api/*.csproj ./src/RadioSchedulingSystem.Api/
COPY src/RadioSchedulingSystem.Application/*.csproj ./src/RadioSchedulingSystem.Application/
COPY src/RadioSchedulingSystem.Domain/*.csproj ./src/RadioSchedulingSystem.Domain/
COPY tests/RadioSchedulingSystem.Tests/*.csproj ./tests/RadioSchedulingSystem.Tests/

RUN dotnet restore RadioSchedulingSystem.sln

COPY . .

RUN dotnet publish src/RadioSchedulingSystem.Api/RadioSchedulingSystem.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

RUN mkdir -p /app/Logs

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080
ENTRYPOINT ["dotnet", "RadioSchedulingSystem.Api.dll"]