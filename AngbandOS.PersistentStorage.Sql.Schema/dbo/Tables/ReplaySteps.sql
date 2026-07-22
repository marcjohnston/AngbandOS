CREATE TABLE [dbo].[ReplaySteps] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [GameReplayId] INT           NOT NULL,
    [DateTime]     DATETIME2 (7) NOT NULL,
    [Keystroke]    NCHAR (1)     NOT NULL,
    [Seed]         INT           NOT NULL,
    CONSTRAINT [PK_GameReplaySequences] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ReplaySteps_GameReplays] FOREIGN KEY ([GameReplayId]) REFERENCES [dbo].[GameRecoveries] ([Id])
);

