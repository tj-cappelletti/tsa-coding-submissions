ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE
    (
        NAME = [Log],
        FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_Primary.ldf',
        SIZE = 8192 KB,
        MAXSIZE = 2097152 MB,
        FILEGROWTH = 65536 KB
    );