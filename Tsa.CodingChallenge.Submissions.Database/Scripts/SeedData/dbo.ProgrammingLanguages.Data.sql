SET IDENTITY_INSERT dbo.ProgrammingLanguages ON

MERGE dbo.ProgrammingLanguages AS [target]
USING ( VALUES (1, 'DONT-NET_C-SHARP_F-SHARP_VB-NET', '.NET (C#, F#, VB.NET)', NULL),
               (2, 'C_C-PLUS-PLUS', 'C/C++', NULL),
               (3, 'JAVA', 'Java', NULL),
               (4, 'NODE_JS', 'Node.js', NULL),
               (5, 'PERL', 'Perl', NULL),
               (6, 'PYTHON', 'Python', NULL),
               (7, 'RUBY', 'Ruby', NULL))
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

SET IDENTITY_INSERT dbo.ProgrammingLanguages OFF