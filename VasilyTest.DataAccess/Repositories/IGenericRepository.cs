using System.Collections.Generic;
using System.Threading.Tasks;

namespace VasilyTest.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();

        Task<T> AddAsync(T entity);
    }
}
