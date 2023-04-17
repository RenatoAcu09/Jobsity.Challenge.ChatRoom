#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Jobsity.Challenge.ChatRoom.UI.Web/Jobsity.Challenge.ChatRoom.UI.Web.csproj", "Jobsity.Challenge.ChatRoom.UI.Web/"]
COPY ["Jobsity.Challenge.ChatRoom.CrossCutting/Jobsity.Challenge.ChatRoom.CrossCutting.csproj", "Jobsity.Challenge.ChatRoom.CrossCutting/"]
COPY ["Jobsity.Challenge.ChatRoom.UseCases/Jobsity.Challenge.ChatRoom.UseCases.csproj", "Jobsity.Challenge.ChatRoom.UseCases/"]
COPY ["Jobsity.Challenge.ChatRoom.Infra/Jobsity.Challenge.ChatRoom.Infra.csproj", "Jobsity.Challenge.ChatRoom.Infra/"]
COPY ["Jobsity.Challenge.ChatRoom.Core/Jobsity.Challenge.ChatRoom.Core.csproj", "Jobsity.Challenge.ChatRoom.Core/"]
COPY ["Jobsity.Challenge.ChatRoom.Domain/Jobsity.Challenge.ChatRoom.Domain.csproj", "Jobsity.Challenge.ChatRoom.Domain/"]
COPY ["Jobsity.Challenge.ChatRoom.Interfaces/Jobsity.Challenge.ChatRoom.Interfaces.csproj", "Jobsity.Challenge.ChatRoom.Interfaces/"]
RUN dotnet restore "Jobsity.Challenge.ChatRoom.UI.Web/Jobsity.Challenge.ChatRoom.UI.Web.csproj"
COPY . .
WORKDIR "/src/Jobsity.Challenge.ChatRoom.UI.Web"
RUN dotnet build "Jobsity.Challenge.ChatRoom.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jobsity.Challenge.ChatRoom.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jobsity.Challenge.ChatRoom.UI.Web.dll"]