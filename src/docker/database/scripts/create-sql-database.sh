#!/bin/sh

# Launch SQL Server as a background process
# Direct stdout to null but allow errors to be written to the console
/opt/mssql/bin/sqlservr > /dev/null &

# Variables to check if SQL Server starts in a timely manner
sqlCheckCount=0
sqlIsAlive=0

# Loop to wait for SQL Server to startup
while [ $sqlCheckCount -lt 4 ]
do
	echo "Waiting for SQL Server to start..."
	sleep 5

	# Try a command that will tell us if SQL Server is running
	# Dump all output to null, we expect some errors while starting
	echo "Checking if SQL Server has started..."
	/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -Q "SELECT TOP 1 * FROM sys.dabases" > /dev/null 2>&1

	# Break loop if the query was sucessful
	if [ $? -eq 0 ]
	then
		sqlCheckCount=5
		sqlIsAlive=1
	else
		sqlCheckCount=$(( $sqlCheckCount + 1))
	fi
done

# If SQL Server didn't start, return a non-successful code
if [ $sqlIsAlive -eq 0 ]
then
	echo "SQL Server failed to start in a timely manner..."
	exit 1
fi

# Run the script to create the database
echo "SQL Server is running, creating database..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i /create-db.sql