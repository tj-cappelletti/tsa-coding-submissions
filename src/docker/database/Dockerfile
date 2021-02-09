FROM mcr.microsoft.com/mssql/server:2019-latest AS base

FROM mcr.microsoft.com/mssql/server:2019-latest AS build
ENV ACCEPT_EULA Y
#TODO: Randomize password for added security
ENV SA_PASSWORD rIMdEnfnHj395cFO
WORKDIR /artifacts
COPY ["artifacts/Tsa.CodingChallenge.Submissions.Database.dacpac", "Tsa.CodingChallenge.Submissions.Database.dacpac"]
COPY ["scripts/*.*", "./"]
USER root
# Ensure script has execute permissions
RUN chmod a+x ./install-sqlpackage.sh
RUN ./install-sqlpackage.sh
USER mssql
# Ensure script has execute permissions
RUN chmod a+x ./create-sql-database.sh
RUN ./create-sql-database.sh

FROM base AS final
COPY ["scripts/start-sqlserver.sh", "/opt/mssql/bin/start-sqlserver.sh"]
COPY --from=build /var/opt/mssql/data/tsa-coding-submissions.mdf /var/opt/mssql/tsa-coding-submissions.mdf
CMD [ "/opt/mssql/bin/start-sqlserver.sh" ]