#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/QuestionAndChalleger.Api/QuestionAndChalleger.Api.csproj", "src/QuestionAndChalleger.Api/"]
COPY ["src/QuestionAndChalleger.Data/QuestionAndChalleger.Data.csproj", "src/QuestionAndChalleger.Data/"]
COPY ["src/QuestionAndChalleger.Manager/QuestionAndChalleger.Manager.csproj", "src/QuestionAndChalleger.Manager/"]
COPY ["src/QuestionAndChalleger.Domain/QuestionAndChalleger.Domain.csproj", "src/QuestionAndChalleger.Domain/"]
RUN dotnet restore "src/QuestionAndChalleger.Api/QuestionAndChalleger.Api.csproj"
COPY . .
WORKDIR "/src/src/QuestionAndChalleger.Api"
RUN dotnet build "QuestionAndChalleger.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuestionAndChalleger.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuestionAndChalleger.Api.dll"]
