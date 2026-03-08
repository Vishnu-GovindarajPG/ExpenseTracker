FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/ExpenseTracker.ApiGateway.csproj src/
RUN dotnet restore src/ExpenseTracker.ApiGateway.csproj

COPY src/ src/
RUN dotnet publish src/ExpenseTracker.ApiGateway.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ExpenseTracker.ApiGateway.dll"]
