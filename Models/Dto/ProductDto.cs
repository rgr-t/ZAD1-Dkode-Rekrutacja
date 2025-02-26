namespace MyApi.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Ean { get; set; }
        public string ProducerName { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public string ChildCategory { get; set; }
        public bool? Available { get; set; }
        public bool? IsVendor { get; set; }
        public string DefaultImage { get; set; }
    }
}