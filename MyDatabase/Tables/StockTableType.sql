-- Stock table type, used in stock merging procedure.

CREATE TYPE stock_table_type AS TABLE
(		
	[sku] NVARCHAR(50) NOT NULL UNIQUE,	
	[quantity] DECIMAL(10,3)
)