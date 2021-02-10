# TSA Coding Submissions Database
This Dockerfile creates a container with the TSA Coding Submissions database deployed onto it.
Built off of the SQL Server Linux container, using the `2019-latest` tag, the Dockerfile uses a `build` layer to create the MDF file.
This layer provides a safe way to create and publish the database without embedding the `sa` password into the final image and the build logs.
Once the MDF file is created, it is detached and then copied onto the `final` layer along with a startup script.
This startup script launches SQL Server as a background process.
The script then waits for SQL Server to accept connections.
Once running, it attaches the MDF file that was created in the `build` layer.
The final step of the script is to bring the SQL Server process (`/opt/mssql/bin/sqlservr`) to the foreground to allow the container to be long running.

## Building the Container
The database project, located at `src/Tsa.CodingChallenge.Submissions.Database`, needs to be built and the DACPAC copied to an `artifacts` folder next to the `Dockerfile`.
If you build the project via command line or through Visual Studio, it will copy the DACPAC to the folder.

Next step is to run Docker command to build the container.
The following command assumes you are running the command at the root directory of the repository:

```
docker build --tag webstorm.acr.io/tsa/coding/submissions/database --file .\src\docker\database\Dockerfile .\src\docker\database\
```

Feel free to change the tag as you see fit for your environment.

## Running the Container
Once the container is built, you run it as very similiarly as you would run a SQL Server Linux container (see [Quickstart: Run SQL Server container images with Docker][run-sql-container]).

The reason for this is to ensure `build` layer is to ensure the security of the running container isn't compromised

## Known Limitations
- You cannot override or pass arguments directly into the SQL Server process
  - This is due to the startup script not checking for arguments passed into the container
- The startup script does not support stopping and starting the container
  - Because the entrypoint is the `start-sqlserver.sh` script, it needs to understand the difference between first start and subsequent starts to not attempt to attach a database that is already attached
- The MDF file cannot exist inside the data directory at first launch
  - SQL Server does a check at start for files inside the data directory and if it finds a file not expected, it will not start normally
- Logging of `start-sqlserver.sh` does not go to the console
  - Due to the way SQL Server is run in the background, the `echo` commands don't end up in the log/console window

## Technical Debt
- Script consolidation
  - Several blocks of the scripts are copy/paste jobs and need to be cleaned up
- Build layer `sa` password should be randomized
  - This adds additional security making it more difficult to attack the container and layers

<!-- Links -->
[run-sql-container]: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell "Quickstart: Run SQL Server container images with Docker"