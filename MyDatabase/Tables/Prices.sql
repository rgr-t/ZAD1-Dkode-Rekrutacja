-- Prices table

CREATE TABLE [dbo].[prices]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	[sku] NVARCHAR(50) NOT NULL UNIQUE,	
	[price_after_discount] DECIMAL(10,2),
	[vat] INT,
	[price_after_discount_for_product_logistic_unit] DECIMAL(10,2)
);