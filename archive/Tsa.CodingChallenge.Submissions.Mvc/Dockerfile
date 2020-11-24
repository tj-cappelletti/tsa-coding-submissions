FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Tsa.CodingChallenge.Submissions.Mvc/Tsa.CodingChallenge.Submissions.Mvc.csproj Tsa.CodingChallenge.Submissions.Mvc/
COPY Tsa.CodingChallenge.Submissions.Core/Tsa.CodingChallenge.Submissions.Core.csproj Tsa.CodingChallenge.Submissions.Core/
RUN dotnet restore Tsa.CodingChallenge.Submissions.Mvc/Tsa.CodingChallenge.Submissions.Mvc.csproj
COPY . .
WORKDIR /src/Tsa.CodingChallenge.Submissions.Mvc
RUN dotnet build Tsa.CodingChallenge.Submissions.Mvc.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Tsa.CodingChallenge.Submissions.Mvc.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tsa.CodingChallenge.Submissions.Mvc.dll"]
