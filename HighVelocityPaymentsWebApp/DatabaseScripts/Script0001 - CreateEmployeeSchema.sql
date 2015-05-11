CREATE TABLE [dbo].[Employee]
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [Name] VARCHAR(1000) NOT NULL, 
    [NumberOfDependents] INT NOT NULL
)