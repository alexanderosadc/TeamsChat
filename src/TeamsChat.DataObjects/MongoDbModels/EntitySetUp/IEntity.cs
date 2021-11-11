using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TeamsChat.DataObjects.MongoDbModels.EntitySetUp
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
