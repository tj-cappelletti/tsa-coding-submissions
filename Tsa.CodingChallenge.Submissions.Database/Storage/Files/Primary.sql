ALTER DATABASE [$(DatabaseName)]
    ADD FILE
    (
        NAME = [Primary],
        FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf',
        SIZE = 8192 KB,
        FILEGROWTH = 65536 KB
    ) TO FILEGROUP [PRIMARY];