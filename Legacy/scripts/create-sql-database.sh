/opt/mssql/bin/sqlservr &

SQL_PID=$!

sleep 15

/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i /create-db.sql

kill $SQL_PID