CREATE TABLE [dbo].[LoginTeamMembers]
(
    [Id] INT NOT NULL IDENTITY,
    [MemberId] VARCHAR(1000) NOT NULL,
    CONSTRAINT [PK_LoginTeamMembers] PRIMARY KEY ([Id])
);