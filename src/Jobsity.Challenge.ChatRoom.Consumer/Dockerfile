#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jobsity.Challenge.ChatRoom.Consumer/Jobsity.Challenge.ChatRoom.Consumer.csproj", "Jobsity.Challenge.ChatRoom.Consumer/"]
COPY ["Jobsity.Challenge.ChatRoom.Core/Jobsity.Challenge.ChatRoom.Core.csproj", "Jobsity.Challenge.ChatRoom.Core/"]
RUN dotnet restore "Jobsity.Challenge.ChatRoom.Consumer/Jobsity.Challenge.ChatRoom.Consumer.csproj"
COPY . .
WORKDIR "/src/Jobsity.Challenge.ChatRoom.Consumer"
RUN dotnet build "Jobsity.Challenge.ChatRoom.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jobsity.Challenge.ChatRoom.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jobsity.Challenge.ChatRoom.Consumer.dll"]