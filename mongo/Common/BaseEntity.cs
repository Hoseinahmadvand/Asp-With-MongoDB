using MongoDB.Bson.Serialization.Attributes;

namespace mongo.Common
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
