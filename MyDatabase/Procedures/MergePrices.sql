CREATE PROCEDURE [dbo].[merge_prices]
    @pricesParamsTable [dbo].[price_table_type] READONLY
AS
BEGIN
    
    MERGE INTO [dbo].[prices] AS target
    USING @pricesParamsTable AS source
    ON target.sku = source.sku
        
    WHEN MATCHED AND
        (
        target.sku != source.sku OR        
        target.price_after_discount != source.price_after_discount OR
        target.vat != source.vat OR
        target.price_after_discount_for_product_logistic_unit != source.price_after_discount_for_product_logistic_unit        
        )                
    THEN UPDATE SET        
        target.sku = source.sku,   
        target.price_after_discount = source.price_after_discount,
        target.vat = source.vat,
        target.price_after_discount_for_product_logistic_unit = source.price_after_discount_for_product_logistic_unit   
        

    WHEN NOT MATCHED THEN
        INSERT 
            (                
                sku,                
                price_after_discount,
                vat,
                price_after_discount_for_product_logistic_unit                
            )
        VALUES 
            (                
                source.sku,                
                source.price_after_discount,
                source.vat,
                source.price_after_discount_for_product_logistic_unit                
            );
    
    SELECT @@ROWCOUNT AS RowsAffected;
END