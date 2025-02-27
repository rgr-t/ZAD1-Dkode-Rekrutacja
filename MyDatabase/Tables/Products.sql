-- Products table

CREATE TABLE [dbo].[products]
(
	[id] INT NOT NULL PRIMARY KEY,
	[sku] NVARCHAR(50) NOT NULL UNIQUE,		
	[producer_name] NVARCHAR(MAX),
    [main_category] NVARCHAR(MAX),
    [sub_category] NVARCHAR(MAX),
	[is_vendor] BIT	
);