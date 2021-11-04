using System;
using TeamsChat.Data.Repository;
using TeamsChat.DataObjects.MSSQLModels;


namespace TeamsChat.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity, new();

        void BeginTransaction();

        void CommitTransaction();

        int SaveChanges();
    }
}
