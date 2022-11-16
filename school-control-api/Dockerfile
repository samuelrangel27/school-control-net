FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ./*.csproj ./

RUN dotnet restore

COPY ./. ./

RUN dotnet publish -c release -o /app-build

FROM mcr.microsoft.com/dotnet/aspnet:6.0

workdir /app

COPY --from=build /app-build ./

ENTRYPOINT [ "dotnet", "school-control-net.dll" ]
