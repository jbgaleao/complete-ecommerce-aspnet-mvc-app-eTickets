using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, Object>>[ ] includeProperties);
        Task<T> GetByIdAsync(Int32 id);
        Task AddAsync(T entity);
        Task UpdateAsync(Int32 id, T entity);
        Task DeleteAsync(Int32 id);
    }
}
