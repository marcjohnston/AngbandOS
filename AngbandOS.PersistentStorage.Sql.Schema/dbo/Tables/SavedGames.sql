CREATE TABLE [dbo].[SavedGames] (
    [Guid]               UNIQUEIDENTIFIER NOT NULL,
    [UserId]             VARCHAR (36)     NOT NULL,
    [Level]              INT              NOT NULL,
    [Gold]               INT              NOT NULL,
    [CharacterName]      VARCHAR (255)    NOT NULL,
    [Comments]           VARCHAR (1024)   NOT NULL,
    [IsAlive]            BIT              NOT NULL,
    [DateTime]           DATETIME2 (7)    NOT NULL,
    [SavedGameContentId] INT              NOT NULL,
    CONSTRAINT [PK_SavedGames_1] PRIMARY KEY CLUSTERED ([Guid] ASC),
    CONSTRAINT [FK_SavedGames_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_SavedGames_SavedGameContents] FOREIGN KEY ([SavedGameContentId]) REFERENCES [dbo].[SavedGameContents] ([Id]) ON DELETE CASCADE
);

