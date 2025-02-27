CREATE PROCEDURE [dbo].[merge_products]
	@productsParamTable [dbo].[product_table_type] READONLY
AS
    BEGIN	    

	    MERGE INTO [dbo].[products] AS target
	    USING @productsParamTable AS source
	    ON target.id = source.id

	            WHEN MATCHED AND 
                (
                    target.sku != source.sku OR
                    target.producer_name != source.producer_name OR
                    target.main_category != source.main_category OR
                    target.sub_category != source.sub_category OR
                    target.is_vendor != source.is_vendor                    
                ) 
        THEN
		    UPDATE SET
		        target.sku = source.sku,
                target.producer_name = source.producer_name,
                target.main_category = source.main_category,
                target.sub_category = source.sub_category,
                target.is_vendor = source.is_vendor

        WHEN NOT MATCHED THEN
            INSERT         
                (
                    id,
                    sku,
                    producer_name,
                    main_category,
                    sub_category,
                    is_vendor                    
                )
            VALUES 
                (
                    source.id,
                    source.sku,
                    source.producer_name, 
                    source.main_category,
                    source.sub_category,
                    source.is_vendor
                );

        SELECT @@ROWCOUNT AS RowsAffected;
    END;