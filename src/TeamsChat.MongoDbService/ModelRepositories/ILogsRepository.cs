using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.Repository;

namespace TeamsChat.MongoDbService.ModelRepositories
{
    public interface ILogsRepository : IMongoDbRepository<Logs>
    {
    }
}
