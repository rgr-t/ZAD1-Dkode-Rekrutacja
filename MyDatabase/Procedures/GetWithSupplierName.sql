CREATE PROCEDURE [dbo].[get_with_supplier_name]
	@supplierName NVARCHAR(MAX)
AS
	BEGIN
		SELECT 
			p.producer_name AS 'SupplierName',
			p.main_category AS 'MainCategory',
			p.sub_category AS 'SubCategory',
			SUM(s.quantity) AS 'TotalStockQuantity',
			CAST(AVG(pr.price_after_discount_for_product_logistic_unit * (1 + pr.vat / 100.0)) AS DECIMAL(10,2))  AS 'AvgPriceIncludingVat',
			CAST(SUM(s.quantity * pr.price_after_discount * (1 + pr.vat / 100.0)) AS DECIMAL(10,2)) AS 'TotalStockValueIncludingVAT',
			CASE
				WHEN
					p.is_vendor = 0 THEN 'Warehouse'
				ELSE
					'Supplier'
			END AS 'ShippedBy'
		
		FROM products p	
			JOIN 
				stock s ON p.sku = s.sku
			JOIN
				prices pr ON p.sku = pr.sku
		WHERE 
			p.producer_name = @supplierName
		GROUP BY
			p.producer_name,
			p.main_category,
			p.sub_category,
			p.is_vendor;
	END;