using System.Threading.Tasks;

namespace Tsa.Coding.Submissions.Core.Repositories
{
    public interface IRepositoryModifierAsync<T>
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
