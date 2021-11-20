
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.Context;
using TeamsChat.MongoDbService.Repository;

namespace TeamsChat.MongoDbService.ModelRepositories
{
    public class LogsRepository : MongoDbRepository<Logs>, ILogsRepository
    {
        public LogsRepository(IMongoDbContext context) : base(context)
        {
        }
    }
}
