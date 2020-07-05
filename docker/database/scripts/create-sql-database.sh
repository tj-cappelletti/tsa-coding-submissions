/opt/mssql/bin/sqlservr &

SQL_PID=$!

sqlCheckCount=0
sqlIsAlive=false

while [ $sqlCheckCount -lt 4 ]
do
	echo "Waiting for SQL Server to start..."
	sleep 15

	echo "Checking if SQL Server has started..."
	/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -Q "SELECT * FROM sys.dabases"

	if [ $? -eq 0 ]
	then
		sqlCheckCount=5
		sqlIsAlive=true
	else
		sqlCheckCount=$(( $sqlCheckCount + 1))
	fi
done

if [ "$sqlIsAlive" == false ]
then
	echo "SQL Server failed to start in a timely manner..."
	exit 1
fi

echo "SQL Server is running, creating database..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i /create-db.sql

echo "Shutting down SQL Server..."
kill $SQL_PID