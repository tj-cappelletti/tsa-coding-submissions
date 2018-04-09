CREATE TABLE [dbo].[Logins]
(
    [Id] INT NOT NULL IDENTITY,
    [Identity] VARCHAR(1000) NOT NULL,
    [RoleId] INT NOT NULL,
    [PasswordHash] VARCHAR(4000) NOT NULL,
    CONSTRAINT [PK_Logins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Logins_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);
GO

CREATE UNIQUE INDEX [UX_Logins_Identity] ON [dbo].[Logins] ([Identity])