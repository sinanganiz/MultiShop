namespace MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

public class GetByIdProductDetailDto
{
    public required string ProductDetailId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInformation { get; set; }
    public string ProductId { get; set; }
}