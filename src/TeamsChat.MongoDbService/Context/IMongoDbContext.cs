using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace TeamsChat.MongoDbService.Context
{
    public interface IMongoDbContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
