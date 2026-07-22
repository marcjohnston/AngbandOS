CREATE TABLE [dbo].[Games] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Seed]          INT            NOT NULL,
    [Username]      VARCHAR (255)  NOT NULL,
    [Level]         INT            NOT NULL,
    [Gold]          INT            NOT NULL,
    [CharacterName] VARCHAR (255)  NOT NULL,
    [Comments]      VARCHAR (1024) NOT NULL,
    [IsAlive]       BIT            NOT NULL,
    [DateTime]      DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC)
);

