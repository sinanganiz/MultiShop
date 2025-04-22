namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductDto
    {
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryId { get; set; }
    }
}
