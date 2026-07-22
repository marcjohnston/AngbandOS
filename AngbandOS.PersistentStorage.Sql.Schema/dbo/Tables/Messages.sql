CREATE TABLE [dbo].[Messages] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FromUserId]   VARCHAR (36)  NOT NULL,
    [ToUserId]     VARCHAR (36)  NULL,
    [Content]      VARCHAR (MAX) NOT NULL,
    [SentDateTime] DATETIME      NOT NULL,
    [Type]         INT           NOT NULL,
    [GameId]       VARCHAR (36)  NULL,
    [IsDeleted]    BIT           CONSTRAINT [DF_Messages_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Messages_AspNetUsers] FOREIGN KEY ([FromUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Messages_AspNetUsers1] FOREIGN KEY ([ToUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

