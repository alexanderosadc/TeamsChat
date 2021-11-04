using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamsChat.DataObjects.MongoDbModels
{
    public class Logs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
