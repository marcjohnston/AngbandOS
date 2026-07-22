CREATE TABLE [dbo].[PersistedGrants] (
    [Key]          NVARCHAR (200) NOT NULL,
    [Type]         NVARCHAR (50)  NOT NULL,
    [SubjectId]    NVARCHAR (200) NULL,
    [SessionId]    NVARCHAR (100) NULL,
    [ClientId]     NVARCHAR (200) NOT NULL,
    [Description]  NVARCHAR (200) NULL,
    [CreationTime] DATETIME2 (7)  NOT NULL,
    [Expiration]   DATETIME2 (7)  NULL,
    [ConsumedTime] DATETIME2 (7)  NULL,
    [Data]         NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_PersistedGrants] PRIMARY KEY CLUSTERED ([Key] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_ConsumedTime]
    ON [dbo].[PersistedGrants]([ConsumedTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_Expiration]
    ON [dbo].[PersistedGrants]([Expiration] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_SubjectId_ClientId_Type]
    ON [dbo].[PersistedGrants]([SubjectId] ASC, [ClientId] ASC, [Type] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PersistedGrants_SubjectId_SessionId_Type]
    ON [dbo].[PersistedGrants]([SubjectId] ASC, [SessionId] ASC, [Type] ASC);

