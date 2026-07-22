CREATE TABLE [dbo].[GameRecoveries] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [UserId]     VARCHAR (36)     NOT NULL,
    [GameGuid]   UNIQUEIDENTIFIER NOT NULL,
    [Seed]       INT              NOT NULL,
    [LastPlayed] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_GameReplays] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GameRecoveries_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [UQ_GameReplays] UNIQUE NONCLUSTERED ([Id] ASC)
);

