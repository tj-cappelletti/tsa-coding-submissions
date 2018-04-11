CREATE TABLE [dbo].[DataTypes]
(
    [Id] INT NOT NULL IDENTITY,
    [Identifier] VARCHAR (100) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    [Description] VARCHAR(MAX),
    CONSTRAINT [PK_DataTypes] PRIMARY KEY ([Id]),
);
GO

CREATE UNIQUE INDEX [UX_DataTypes_Identifier] on [dbo].[DataTypes] ([Identifier]);
GO