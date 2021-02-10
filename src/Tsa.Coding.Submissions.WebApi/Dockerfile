#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Tsa.Coding.Submissions.WebApi/Tsa.Coding.Submissions.WebApi.csproj", "Tsa.Coding.Submissions.WebApi/"]
COPY ["Tsa.Coding.Submissions.Core/Tsa.Coding.Submissions.Core.csproj", "Tsa.Coding.Submissions.Core/"]
RUN dotnet restore "Tsa.Coding.Submissions.WebApi/Tsa.Coding.Submissions.WebApi.csproj"
COPY . .
WORKDIR "/src/Tsa.Coding.Submissions.WebApi"
RUN dotnet build "Tsa.Coding.Submissions.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tsa.Coding.Submissions.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tsa.Coding.Submissions.WebApi.dll"]
