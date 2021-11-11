using System;
using System.Threading.Tasks;

namespace TeamsChat.MongoDbService.UnitOfWork
{
    public interface IMongoDbUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
