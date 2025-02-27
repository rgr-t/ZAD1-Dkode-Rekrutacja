CREATE PROCEDURE [dbo].[merge_stocks]
    @stocksParamsTable [dbo].[stock_table_type] READONLY
AS
BEGIN
    
    MERGE INTO [dbo].[stock] AS target
    USING @stocksParamsTable AS source
    ON target.sku = source.sku
        
    WHEN MATCHED AND
        (             
        target.quantity != source.quantity
        )                
    THEN UPDATE SET             
        target.quantity = source.quantity

    WHEN NOT MATCHED THEN
        INSERT 
            (                
                sku,                
                quantity
            )
        VALUES 
            (                
                source.sku,                
                source.quantity
            );
    
    SELECT @@ROWCOUNT AS RowsAffected;
END