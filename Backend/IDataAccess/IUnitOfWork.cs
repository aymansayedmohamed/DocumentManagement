using System;
using System.Data.Entity;


namespace IDataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
