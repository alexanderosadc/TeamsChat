using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TeamsChat.MongoDbService.Repository
{
    public interface IMongoDbRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetFiltered(Expression<Func<TEntity, bool>> filterExpression);
        void Insert(TEntity entity);
    }
}
