using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string ProductDetailId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInformation { get; set; }
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}