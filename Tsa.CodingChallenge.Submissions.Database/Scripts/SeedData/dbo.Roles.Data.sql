SET IDENTITY_INSERT dbo.Roles ON

MERGE dbo.Roles AS [target]
USING ( VALUES (1, 'JUDGE', 'Judge', NULL),
               (2, 'TEAM_PARTICIPANT', 'Team Participant', NULL))
               AS [source] (Id, Identifier, [Name], [Description])
ON [target].Id = [source].Id
WHEN MATCHED AND [target].Identifier != [source].Identifier
             OR  [target].[Name] != [source].[Name]
             OR  [target].[Description] != [source].[Description]
    THEN UPDATE SET	[target].Identifier = [source].Identifier,
                    [target].[Name] = [source].[Name],
                    [target].[Description] = [source].[Description]
WHEN NOT MATCHED
    THEN	INSERT (Id, Identifier, [Name], [Description])
            VALUES (Id, Identifier, [Name], [Description]);

SET IDENTITY_INSERT dbo.Roles OFF