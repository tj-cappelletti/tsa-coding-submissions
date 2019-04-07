SET IDENTITY_INSERT dbo.ProgrammingLanguages ON

MERGE dbo.ProgrammingLanguages AS [target]
USING ( VALUES (1,'C','C',NULL),
               (2,'CPLUSPLUS','C++',NULL),
               (3,'CSHARP','C#',NULL),
               (4,'FSHARP','F#',NULL),
               (5,'JAVA','Java',NULL),
               (6,'NODEJS','Node.js',NULL),
               (7,'PERL','Perl',NULL),
               (8,'PYTHON','Python',NULL),
               (9,'RUBY','Ruby',NULL),
               (10,'VBDOTNET','VB.NET',NULL))
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