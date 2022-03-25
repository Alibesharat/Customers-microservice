#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/CustomerServiceApp/CustomerServiceApp.csproj", "Services/CustomerServiceApp/"]
COPY ["Infrastructure/MessageBroker/MessageBroker.csproj", "Infrastructure/MessageBroker/"]
COPY ["Infrastructure/Models/Models.csproj", "Infrastructure/Models/"]
COPY ["Infrastructure/DAL/DAL.csproj", "Infrastructure/DAL/"]
COPY ["Infrastructure/GrpcModelFirst/GrpcModelFirst.csproj", "Infrastructure/GrpcModelFirst/"]
RUN dotnet restore "Services/CustomerServiceApp/CustomerServiceApp.csproj"
COPY . .
WORKDIR "/src/Services/CustomerServiceApp"
RUN dotnet build "CustomerServiceApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerServiceApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerServiceApp.dll"]