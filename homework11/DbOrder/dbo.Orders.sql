CREATE TABLE [dbo].[Orders] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Customer]   NVARCHAR (MAX) NULL,
    [OrderDate]  DATETIME       NULL,
    [Totalmoney] INT            NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

