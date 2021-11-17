using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamsChat.MongoDbService.Repository
{
    public interface IMongoDbRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filterExpression);
        void Insert(TEntity entity);
    }
}
