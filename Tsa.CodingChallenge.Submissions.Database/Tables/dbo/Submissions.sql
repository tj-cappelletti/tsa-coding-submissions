CREATE TABLE [dbo].[Submissions]
(
    [Id] INT NOT NULL IDENTITY,
    [LoginId] INT NOT NULL,
    [ProblemId] INT NOT NULL,
    [SubmissionDateTime] DATETIME NOT NULL,
    [EvaluatedDateTime] DATETIME NOT NULL,
    [ProgrammingLanguageId] INT NOT NULL,
    [FileName] VARCHAR(1000) NOT NULL,
    [RawFile] VARBINARY(MAX) NOT NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submissions_Logins] FOREIGN KEY ([LoginId]) REFERENCES [dbo].[Logins]([Id]),
    CONSTRAINT [FK_Submissions_Problems] FOREIGN KEY ([ProblemId]) REFERENCES [dbo].[Problems]([Id]),
    CONSTRAINT [FK_Submissions_ProgrammingLanguages] FOREIGN KEY ([ProgrammingLanguageId]) REFERENCES [dbo].[ProgrammingLanguages]([Id])
);