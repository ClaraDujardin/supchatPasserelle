# Use SDK image for both stages
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use SDK image for runtime as well
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copy the entire source code
COPY . .

# Install and configure EF Core tools
RUN dotnet new tool-manifest --force
RUN dotnet tool install dotnet-ef --version 8.0.0
RUN dotnet tool restore

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "run", "--urls", "http://0.0.0.0:8080"]
