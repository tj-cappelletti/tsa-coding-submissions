CREATE TABLE [dbo].[Submissions]
(
    [Id] INT NOT NULL IDENTITY,
    [ProblemId] INT NOT NULL,
    [SubmissionFileId] UNIQUEIDENTIFIER NOT NULL,
    [SubmissionDateTime] DATETIME NOT NULL,
    [EvaluatedDateTime] DATETIME NOT NULL,
    CONSTRAINT [PK_Submissions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Submissions_SubmissionFiles] FOREIGN KEY ([SubmissionFileId]) REFERENCES [dbo].[SubmissionFiles]([stream_id])
);