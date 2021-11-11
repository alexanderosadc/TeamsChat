using MongoDB.Bson;
using System;

namespace TeamsChat.DataObjects.MongoDbModels.EntitySetUp
{
    public abstract class Entity : IEntity
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
