-- Product table type, used in product merging procedure.

CREATE TYPE product_table_type AS TABLE
(
    id INT NOT NULL PRIMARY KEY,
    sku NVARCHAR(50) NOT NULL UNIQUE,
    producer_name NVARCHAR(MAX),
    main_category NVARCHAR(MAX),
    sub_category NVARCHAR(MAX),
    is_vendor BIT    
);