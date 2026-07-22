CREATE TABLE [dbo].[SavedGameContents] (
    [Id]   INT             IDENTITY (1, 1) NOT NULL,
    [Data] VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_SavedGameContents] PRIMARY KEY CLUSTERED ([Id] ASC)
);

