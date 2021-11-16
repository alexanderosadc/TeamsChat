using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TeamsChat.MongoDbService.Context;

namespace TeamsChat.MongoDbService.Repository
{
    public abstract class MongoDbRepository<TEntity> : IMongoDbRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDbContext _context;
        protected IMongoCollection<TEntity> _dbSet;

        protected MongoDbRepository(IMongoDbContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> filterExpression)
        {
            var data = await _dbSet.FindAsync(filterExpression);
            return data.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            //var all = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            var all = _dbSet.Find(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }
        public virtual void Insert(TEntity entity)
        {
            _dbSet.InsertOne(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
