#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jobsity.Challenge.ChatRoom.Bot/Jobsity.Challenge.ChatRoom.Bot.csproj", "Jobsity.Challenge.ChatRoom.Bot/"]
COPY ["Jobsity.Challenge.ChatRoom.Core/Jobsity.Challenge.ChatRoom.Core.csproj", "Jobsity.Challenge.ChatRoom.Core/"]
RUN dotnet restore "Jobsity.Challenge.ChatRoom.Bot/Jobsity.Challenge.ChatRoom.Bot.csproj"
COPY . .
WORKDIR "/src/Jobsity.Challenge.ChatRoom.Bot"
RUN dotnet build "Jobsity.Challenge.ChatRoom.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jobsity.Challenge.ChatRoom.Bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jobsity.Challenge.ChatRoom.Bot.dll"]