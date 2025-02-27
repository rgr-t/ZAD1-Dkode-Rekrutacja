-- Stock table

CREATE TABLE [dbo].[stock]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	[sku] NVARCHAR(50) NOT NULL UNIQUE,	
	[quantity] DECIMAL(10,3)
);