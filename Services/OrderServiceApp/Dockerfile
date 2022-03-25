#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/OrderServiceApp/OrderServiceApp.csproj", "Services/OrderServiceApp/"]
COPY ["Infrastructure/MessageBroker/MessageBroker.csproj", "Infrastructure/MessageBroker/"]
COPY ["Infrastructure/Models/Models.csproj", "Infrastructure/Models/"]
COPY ["Infrastructure/GrpcModelFirst/GrpcModelFirst.csproj", "Infrastructure/GrpcModelFirst/"]
RUN dotnet restore "Services/OrderServiceApp/OrderServiceApp.csproj"
COPY . .
WORKDIR "/src/Services/OrderServiceApp"
RUN dotnet build "OrderServiceApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderServiceApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderServiceApp.dll"]