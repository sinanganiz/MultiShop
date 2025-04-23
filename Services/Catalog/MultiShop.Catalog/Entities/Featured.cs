using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class Featured
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeaturedId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }

    }
}
