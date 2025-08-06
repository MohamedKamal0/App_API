FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app
COPY ["App_API/App_API.csproj","App_API/"]
COPY ["App_API.Domain/App_API.Domain.csproj","App_API.Domain/"]
COPY ["App_API.Infrastructure/App_API.Infrastructure.csproj","App_API.Infrastructure/"]
COPY ["App_API.Service/App_API.Service.csproj","App_API.Service/"]
#COPY".csproj ./

#restore Libraries in distination Directory

RUN dotnet restore "App_API/App_API.csproj"
RUN dotnet restore "App_API.Domain/App_API.Domain.csproj"
RUN dotnet restore "App_API.Infrastructure/App_API.Infrastructure.csproj"
RUN dotnet restore "App_API.Service/App_API.Service.csproj"
#copy EveryThing
COPY . ./
# wbuild and publish release
RUN dotnet publish "App_API/App_API.csproj" -c Release -o out
#build Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "App_API.dll"]