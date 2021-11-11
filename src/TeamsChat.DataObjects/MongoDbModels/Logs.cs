using TeamsChat.DataObjects.MongoDbModels.EntitySetUp;

namespace TeamsChat.DataObjects.MongoDbModels
{
    [BsonCollection("Logs")]
    public class Logs : Entity
    {
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
