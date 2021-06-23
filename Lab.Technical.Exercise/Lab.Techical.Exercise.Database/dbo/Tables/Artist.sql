CREATE TABLE [dbo].[Artist] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR (MAX) NOT NULL,
    [CreationDate] DATETIME NOT NULL DEFAULT GetUtcDate(), 
);

