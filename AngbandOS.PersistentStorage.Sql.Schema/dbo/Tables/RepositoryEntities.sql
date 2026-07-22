CREATE TABLE [dbo].[RepositoryEntities] (
    [RepositoryName] VARCHAR (50)  NOT NULL,
    [Key]            VARCHAR (50)  NOT NULL,
    [JsonData]       VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_RepositoryEntities_1] PRIMARY KEY CLUSTERED ([RepositoryName] ASC, [Key] ASC)
);

