using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tsa.Coding.Submissions.Core.Repositories
{
    public interface IRepositoryReaderAsync<TEntity>
    {
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(int id);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
