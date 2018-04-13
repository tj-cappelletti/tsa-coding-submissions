CREATE TABLE [dbo].[SubmissionTestRuns]
(
    [Id] INT NOT NULL IDENTITY,
    [SubmissionId] INT NOT NULL,
    [TestDataSetId] INT NOT NULL,
    [TestPassed] BIT NOT NULL,
    [TestDuration] TIME NOT NULL,
    CONSTRAINT [PK_SubmissionTestRuns] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubmissionTestRuns_Submissions] FOREIGN KEY ([SubmissionId]) REFERENCES [dbo].[Submissions]([Id]),
    CONSTRAINT [FK_SubmissionTestRuns_TestDataSets] FOREIGN KEY ([TestDataSetId]) REFERENCES [dbo].[TestDataSets]([Id])
);