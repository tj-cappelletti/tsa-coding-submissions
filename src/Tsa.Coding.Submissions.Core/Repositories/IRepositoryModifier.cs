namespace Tsa.Coding.Submissions.Core.Repositories
{
    public interface IRepositoryModifier<T>
    {
        T Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
