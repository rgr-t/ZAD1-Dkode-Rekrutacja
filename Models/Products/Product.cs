﻿namespace MyApi.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Ean { get; set; }
        public string ProducerName { get; set; }
        public string Category { get; set; }
        public bool? IsWire { get; set; }
        public string Shipping { get; set; }
        public bool? Available { get; set; }
        public bool? IsVendor { get; set; }
        public string DefaultImage { get; set; }
    }
}