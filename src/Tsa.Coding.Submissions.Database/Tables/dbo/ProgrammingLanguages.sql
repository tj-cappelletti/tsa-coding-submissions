CREATE TABLE [dbo].[ProgrammingLanguages]
(
    [Id] INT NOT NULL IDENTITY,
    [Identifier] VARCHAR (100) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    [Description] VARCHAR(MAX),
    CONSTRAINT [PK_ProgrammingLanguages] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [UX_ProgrammingLanguages_Identifier] on [dbo].[ProgrammingLanguages] ([Identifier])
GO