CREATE TABLE [dbo].[Stock] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [AlbumId] INT NOT NULL,
    [Quantity]   INT NOT NULL,
    [CreationDate] DATETIME NOT NULL DEFAULT GetUtcDate()
    CONSTRAINT [FK_Stock_Album] FOREIGN KEY ([AlbumId]) REFERENCES [Album]([Id]),
);