CREATE TABLE [dbo].[PropertyTraces]
(
	[IdPropertyTrace] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [DateSale] DATE NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Value] NUMERIC(18, 5) NOT NULL, 
    [Tax] NUMERIC(18, 5) NOT NULL, 
    [IdProperty] BIGINT NOT NULL, 
    CONSTRAINT [FK_PropertyTrace_Property] FOREIGN KEY ([IdProperty]) REFERENCES [Properties]([IdProperty])
)
