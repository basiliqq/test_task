using System;
using System.Threading.Tasks;
using VasilyTest.DataAccess.Repositories;

namespace VasilyTest.DataAccess.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
        IGenericRepository<T> Repository<T>() where T : class;
    }
}
