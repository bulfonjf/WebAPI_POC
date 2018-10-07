FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 52597
EXPOSE 44398

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY WebAPI_POC/WebAPI_POC.csproj WebAPI_POC/
RUN dotnet restore WebAPI_POC/WebAPI_POC.csproj
COPY . .
WORKDIR /src/WebAPI_POC
RUN dotnet build WebAPI_POC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebAPI_POC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI_POC.dll"]
