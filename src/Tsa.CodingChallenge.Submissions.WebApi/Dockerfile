#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Tsa.CodingChallenge.Submissions.WebApi/Tsa.CodingChallenge.Submissions.WebApi.csproj", "Tsa.CodingChallenge.Submissions.WebApi/"]
COPY ["Tsa.CodingChallenge.Submissions.Core/Tsa.CodingChallenge.Submissions.Core.csproj", "Tsa.CodingChallenge.Submissions.Core/"]
RUN dotnet restore "Tsa.CodingChallenge.Submissions.WebApi/Tsa.CodingChallenge.Submissions.WebApi.csproj"
COPY . .
WORKDIR "/src/Tsa.CodingChallenge.Submissions.WebApi"
RUN dotnet build "Tsa.CodingChallenge.Submissions.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tsa.CodingChallenge.Submissions.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tsa.CodingChallenge.Submissions.WebApi.dll"]
