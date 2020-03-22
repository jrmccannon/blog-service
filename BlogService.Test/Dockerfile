FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlogService/BlogService.Test.csproj", "BlogService/BlogService.Test/"]
COPY ["BlogService/BlogService.csproj", "BlogService/BlogService/"]
RUN dotnet restore "BlogService/BlogService.Test.csproj"
COPY . .
WORKDIR "/src/BlogService/BlogService.Test"
RUN dotnet build "BlogService/BlogService.Test.csproj" -c Release -o /app/build
