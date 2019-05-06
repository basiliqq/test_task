using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VasilyTest.DataAccess.Db;
using VasilyTest.DataAccess.Repositories;

namespace VasilyTest.DataAccess.UoW.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VasilyTestDbContext _context;
        private Dictionary<Type, object> Repositories { get; } = new Dictionary<Type, object>();

        public UnitOfWork(VasilyTestDbContext dbContext)
        {
            _context = dbContext;
        }

        #region IUnitOfWork

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        #endregion

        #region IDisposable

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
