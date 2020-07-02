CREATE TABLE [dbo].[TestDataSets]
(
    [Id] INT NOT NULL IDENTITY,
    [ProblemId] INT NOT NULL,
    [Identifier] VARCHAR (100) NOT NULL,
    [Sequence] INT NOT NULL,
    [Data] VARCHAR(4000) NOT NULL,
    [ExpectedResult] VARCHAR(4000) NOT NULL,
    [DisplayWithProblem] BIT NOT NULL,
    CONSTRAINT [PK_TestDataSets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TestDataSets_Problems] FOREIGN KEY ([ProblemId]) REFERENCES [dbo].[Problems]([Id])
);
GO