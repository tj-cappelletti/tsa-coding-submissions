USE [master]
GO

ALTER DATABASE [tsa-coding-submissions] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

EXEC dbo.sp_detach_db @dbname = N'tsa-coding-submissions', @skipchecks = 'false'
GO