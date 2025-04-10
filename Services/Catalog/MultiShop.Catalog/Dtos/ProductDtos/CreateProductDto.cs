namespace MultiShop.Catalog.Dtos.ProductDtos;

public class CreateProductDto
{
    public required string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }

    public string CategoryId { get; set; }

}