CREATE TABLE [dbo].[Owners]
(
	[IdOwner] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [Photo] IMAGE NULL, 
    [Birthday] DATE NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    [Deleted] BIT NOT NULL DEFAULT 0
)
