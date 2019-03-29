FROM mcr.microsoft.com/mssql/server:2017-latest

COPY scripts/Tsa.CodingChallenge.Submissions.Database_Create.sql /create-db.sql
COPY scripts/create-sql-database.sh /

ENV ACCEPT_EULA Y
ENV SA_PASSWORD rIMdEnfnHj395cFO

RUN /create-sql-database.sh

CMD [ "/opt/mssql/bin/sqlservr" ]