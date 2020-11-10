#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Tsa.CodingChallenge.Submissions.Blazor/Tsa.CodingChallenge.Submissions.Blazor.csproj", "Tsa.CodingChallenge.Submissions.Blazor/"]
RUN dotnet restore "Tsa.CodingChallenge.Submissions.Blazor/Tsa.CodingChallenge.Submissions.Blazor.csproj"
COPY . .
WORKDIR "/src/Tsa.CodingChallenge.Submissions.Blazor"
RUN dotnet build "Tsa.CodingChallenge.Submissions.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tsa.CodingChallenge.Submissions.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tsa.CodingChallenge.Submissions.Blazor.dll"]