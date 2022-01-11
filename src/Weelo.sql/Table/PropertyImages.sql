CREATE TABLE [dbo].[PropertyImages]
(
	[IdPropertyImage] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [IdProperty] BIGINT NOT NULL, 
    [File] VARBINARY(MAX) NOT NULL, 
    [Enable] BIT NOT NULL, 
    CONSTRAINT [FK_PropertyImage_Property] FOREIGN KEY ([IdProperty]) REFERENCES [Properties]([IdProperty])
)
