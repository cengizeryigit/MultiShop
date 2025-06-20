namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        public string ProductImageID { get; set; }
        public string Images1{ get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
    }
}
