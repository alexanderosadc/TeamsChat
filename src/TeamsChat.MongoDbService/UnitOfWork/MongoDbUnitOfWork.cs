using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.MongoDbService.Context;

namespace TeamsChat.MongoDbService.UnitOfWork
{
    public class MongoDbUnitOfWork : IMongoDbUnitOfWork
    {
        private readonly IMongoDbContext _context;
        private Dictionary<(Type type, string Name), IDisposable> _repositories;

        public MongoDbUnitOfWork(IMongoDbContext context)
        {
            _repositories = new Dictionary<(Type type, string Name), IDisposable>();
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _context.SaveChanges();

            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
