﻿namespace MyApi.Models.Inventory
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string ManufacturerName { get; set; }
        public string Shipping { get; set; }
        public string ShippingCost { get; set; }
    }
}
