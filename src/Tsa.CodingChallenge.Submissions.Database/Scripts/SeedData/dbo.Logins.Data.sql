SET IDENTITY_INSERT dbo.Logins ON

MERGE dbo.Logins AS [target]
USING ( VALUES (1, 'coding-judge', 1, 'sha1:64000:18:ul9QSy4X3RTHSy2ua6XbH4DCXF6qNtS+:gfQMHPycBuxCg/DIqeYb6a8G'))
               AS [source] (Id, [Identity], RoleId, PasswordHash)
ON [target].Id = [source].Id
WHEN MATCHED AND [target].[Identity] != [source].[Identity]
             OR  [target].RoleId != [source].RoleId
             OR  [target].PasswordHash != [source].PasswordHash
    THEN UPDATE SET	[target].[Identity] = [source].[Identity],
                    [target].RoleId = [source].RoleId,
                    [target].PasswordHash = [source].PasswordHash
WHEN NOT MATCHED
    THEN	INSERT (Id, [Identity], RoleId, PasswordHash)
            VALUES (Id, [Identity], RoleId, PasswordHash);

SET IDENTITY_INSERT dbo.Logins OFF