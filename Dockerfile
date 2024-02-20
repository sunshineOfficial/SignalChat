FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SignalChat.Api/SignalChat.Api.csproj", "SignalChat.Api/"]
RUN dotnet restore "SignalChat.Api/SignalChat.Api.csproj"
COPY . .
WORKDIR "/src/SignalChat.Api"
RUN dotnet build "SignalChat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalChat.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalChat.Api.dll"]
