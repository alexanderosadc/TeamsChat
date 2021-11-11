using System;
using TeamsChat.SSMS.Repository;
using TeamsChat.DataObjects.SSMSModels;


namespace TeamsChat.SSMS.UnitOfWork
{
    public interface ISSMSUnitOfWork : IDisposable
    {
        ISSMSRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity, new();

        void BeginTransaction();

        void CommitTransaction();

        int SaveChanges();
    }
}
