SET IDENTITY_INSERT dbo.TestDataSets ON

MERGE dbo.TestDataSets AS [target]
USING ( VALUES (1,1,'PROBLEM_1_TEST_SET_1',0,'[{"sequence":0,"parameter":{"targetType":"Int 32[]","value":[2,3,3,1,5,2]}}]','{3}',1))
               AS [source] (Id, ProblemId, Identifier, [Sequence], [Data], ExpectedResult, DisplayWithProblem)
ON [target].Id = [source].Id
WHEN MATCHED AND [target].ProblemId != [source].ProblemId
             OR  [target].Identifier != [source].Identifier
             OR  [target].[Sequence] != [source].[Sequence]
             OR  [target].[Data] != [source].[Data]
             OR  [target].ExpectedResult != [source].ExpectedResult
             OR  [target].DisplayWithProblem != [source].DisplayWithProblem
    THEN UPDATE SET	[target].ProblemId = [source].ProblemId,
                    [target].Identifier = [source].Identifier,
                    [target].[Sequence] = [source].[Sequence],
                    [target].[Data] = [source].[Data],
                    [target].ExpectedResult = [source].ExpectedResult,
                    [target].DisplayWithProblem = [source].DisplayWithProblem
WHEN NOT MATCHED
    THEN	INSERT (Id, ProblemId, Identifier, [Sequence], [Data], ExpectedResult, DisplayWithProblem)
            VALUES (Id, ProblemId, Identifier, [Sequence], [Data], ExpectedResult, DisplayWithProblem);

SET IDENTITY_INSERT dbo.TestDataSets OFF