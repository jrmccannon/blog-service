FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BlogService/BlogService.csproj", "BlogService/"]

RUN dotnet restore "BlogService/BlogService.csproj"
COPY . .
WORKDIR "/src/BlogService"
RUN dotnet build "BlogService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogService.dll"]