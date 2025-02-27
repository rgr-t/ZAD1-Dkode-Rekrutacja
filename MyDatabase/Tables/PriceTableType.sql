-- Price table type, used in price merging procedure.

CREATE TYPE [dbo].[price_table_type] AS TABLE
(	
	[sku] NVARCHAR(50) NOT NULL UNIQUE,	
	[price_after_discount] DECIMAL(10,2),
	[vat] INT,
	[price_after_discount_for_product_logistic_unit] DECIMAL(10,2)
)