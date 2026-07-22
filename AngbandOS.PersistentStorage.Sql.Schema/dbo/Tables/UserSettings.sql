CREATE TABLE [dbo].[UserSettings] (
    [UserId]   VARCHAR (36) NOT NULL,
    [FontName] VARCHAR (50) NULL,
    [FontSize] INT          NULL,
    [F1Macro]  VARCHAR (10) NULL,
    [F2Macro]  VARCHAR (10) NULL,
    [F3Macro]  VARCHAR (10) NULL,
    [F4Macro]  VARCHAR (10) NULL,
    [F5Macro]  VARCHAR (10) NULL,
    [F6Macro]  VARCHAR (10) NULL,
    [F7Macro]  VARCHAR (10) NULL,
    [F8Macro]  VARCHAR (10) NULL,
    [F9Macro]  VARCHAR (10) NULL,
    [F10Macro] VARCHAR (10) NULL,
    [F11Macro] VARCHAR (10) NULL,
    [F12Macro] VARCHAR (10) NULL,
    CONSTRAINT [PK_UserSettings] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

