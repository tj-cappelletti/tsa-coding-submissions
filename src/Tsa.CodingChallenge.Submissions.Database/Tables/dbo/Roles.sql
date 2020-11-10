CREATE TABLE [dbo].[Roles]
(
    [Id] INT NOT NULL IDENTITY,
    [Identifier] VARCHAR (100) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    [Description] VARCHAR(MAX),
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [UX_Roles_Identifier] on [dbo].[Roles] ([Identifier])
GO