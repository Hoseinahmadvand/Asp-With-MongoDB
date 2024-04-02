using mongo.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace mongo.Models
{
    public class User:BaseEntity
    {
   
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("family")]
        public string Family { get; set; }
        [BsonIgnore]
        public string FullName =>$"{Name}{Family}";
    }
}
