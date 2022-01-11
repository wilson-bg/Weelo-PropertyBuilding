CREATE TABLE [dbo].[Properties]
(
	[IdProperty] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [Price] NUMERIC(18, 5) NULL, 
    [CodeInternal] NVARCHAR(25) NULL, 
    [Year] INT NULL, 
    [IdOwner] BIGINT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Property_Owner] FOREIGN KEY ([IdOwner]) REFERENCES [Owners]([IdOwner]) 
)
