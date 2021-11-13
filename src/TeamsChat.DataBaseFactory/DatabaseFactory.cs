using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.SSMS.UnitOfWork;

namespace TeamsChat.DatabaseInterface
{
    public class DatabaseFactory : IDatabaseFactory
    {
        ISSMSUnitOfWork _ssmsDatabase;
        ILogsRepository _logRepository;
        public DatabaseFactory(ISSMSUnitOfWork ssms, ILogsRepository logRepo)
        {
            _ssmsDatabase = ssms;
            _logRepository = logRepo;
        }

        public T GetDb<T>()
        {
            if (typeof(T) == typeof(ISSMSUnitOfWork))
                return (T)_ssmsDatabase;
            else if (typeof(T) == typeof(ILogsRepository))
                return (T)_logRepository;
            else
                return default(T);

        }
    }
}
