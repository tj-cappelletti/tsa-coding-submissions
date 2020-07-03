CREATE TABLE [dbo].[Problems]
(
    [Id] INT NOT NULL IDENTITY,
    [Identifier]  VARCHAR (100) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Problems] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [UX_Identifier] ON [dbo].[Problems] ([Identifier])
GO