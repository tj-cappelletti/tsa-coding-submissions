CREATE TABLE [dbo].[TestDataSetElements]
(
    [Id] INT NOT NULL IDENTITY,
    [TestDataSetId] INT NOT NULL,
    [Identifier] VARCHAR (100) NOT NULL,
    [Sequence] INT NOT NULL,
    [IsArrayElement] BIT NOT NULL,
    [ArraySequence] INT NULL,
    [DataTypeId] INT NOT NULL,
    [Value] VARCHAR(4000) NOT NULL
    CONSTRAINT [PK_TestDataSetElements] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TestDataSetElements_DataTypes] FOREIGN KEY ([DataTypeId]) REFERENCES [dbo].[TestDataSets]([Id]),
    CONSTRAINT [FK_TestDataSetElements_TestDataSet] FOREIGN KEY ([TestDataSetId]) REFERENCES [dbo].[TestDataSets]([Id])
);
GO