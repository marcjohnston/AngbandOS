CREATE TABLE [dbo].[UserGameConfigurations] (
    [Name]     VARCHAR (50)  NOT NULL,
    [Username] VARCHAR (255) NOT NULL,
    [JsonData] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserGameConfigurations] PRIMARY KEY CLUSTERED ([Name] ASC, [Username] ASC)
);

