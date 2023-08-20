# Use the .NET 6 SDK image as the build environment - used for RPI 4
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim-arm64v8 AS build

# Set the working directory
WORKDIR /src

# Copy the solution file
COPY *.sln .

# Copy the Web API project file and restore its dependencies
COPY Ratsatak.Api/Ratsatak.Api.csproj Ratsatak.Api/

# Copy the class library projects and restore their dependencies
COPY Ratsatak.Infrastructure/Ratsatak.Infrastructure.csproj Ratsatak.Infrastructure/

COPY Ratsatak.Contracts/Ratsatak.Contracts.csproj Ratsatak.Contracts/

COPY Ratsatak.Application/Ratsatak.Application.csproj Ratsatak.Application/

COPY Ratsatak.Domain/Ratsatak.Domain.csproj Ratsatak.Domain/

COPY Ratsatak.Shared/Ratsatak.Shared.csproj Ratsatak.Shared/

COPY Ratsatak.Tests/Ratsatak.Tests.csproj Ratsatak.Tests/
# Repeat this step for any additional class libraries

RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build and publish the Web API project
WORKDIR "/src/Ratsatak.Api"
RUN dotnet build "Ratsatak.Api.csproj" -c Release -o /app/build
RUN dotnet publish "Ratsatak.Api.csproj" -c Release -o /app/publish --no-restore

# Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim-arm64v8 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Ratsatak.Api.dll"]
