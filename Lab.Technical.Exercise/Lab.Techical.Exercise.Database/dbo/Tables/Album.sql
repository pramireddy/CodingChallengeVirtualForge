CREATE TABLE [dbo].[Album] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] VARCHAR (MAX) NOT NULL,
    [AlbumType] INT NOT NULL,
    [ArtistId]  INT NOT NULL,
    [LabelId] INT  NOT NULL,
    [CreationDate] DATETIME NOT NULL DEFAULT GetUtcDate(), 
    [UpdatedDate] DATETIME NULL, 
    CONSTRAINT [FK_Album_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [Artist]([Id]),
    CONSTRAINT [FK_Album_Label] FOREIGN KEY ([LabelId]) REFERENCES [Label]([Id])
);

