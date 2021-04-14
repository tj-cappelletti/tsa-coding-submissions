FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
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
