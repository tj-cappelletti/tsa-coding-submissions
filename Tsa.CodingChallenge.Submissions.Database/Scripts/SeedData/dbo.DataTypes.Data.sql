SET IDENTITY_INSERT dbo.DataTypes ON

MERGE dbo.DataTypes AS [target]
USING ( VALUES (1, 'BOOLEAN', 'Boolean', NULL),
               (2, 'BYTE', 'Byte', NULL),
               (3, 'CHAR', 'Char', NULL),
               (4, 'DECIMAL', 'Decimal', NULL),
               (5, 'DOUBLE', 'Double', NULL),
               (6, 'INT16', 'Int16', NULL),
               (7, 'INT32', 'Int32', NULL),
               (8, 'INT64', 'Int64', NULL),
               (9, 'OBJECT', 'Object', NULL),
               (10, 'SBYTE', 'SByte', NULL),
               (11, 'SINGLE', 'Single', NULL),
               (12, 'STRING', 'String', NULL),
               (13, 'UINT16', 'UInt16', NULL),
               (14, 'UINT32', 'UInt32', NULL),
               (15, 'UINT64', 'UInt64', NULL))
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