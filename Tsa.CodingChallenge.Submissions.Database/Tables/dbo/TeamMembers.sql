CREATE TABLE [dbo].[TeamMembers]
(
    [Id] INT NOT NULL IDENTITY,
    [LoginId] INT NOT NULL,
    [MemberId] VARCHAR(1000) NOT NULL,
    CONSTRAINT [PK_TeamMembers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TeamMembers_Logins] FOREIGN KEY ([LoginId]) REFERENCES [dbo].[Logins]([Id])
);