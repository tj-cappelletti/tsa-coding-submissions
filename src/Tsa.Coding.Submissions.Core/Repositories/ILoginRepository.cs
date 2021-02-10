using Tsa.Coding.Submissions.Core.Entities;

namespace Tsa.Coding.Submissions.Core.Repositories
{
    public interface ILoginRepository : IRepositoryModifier<Login>,
        IRepositoryModifierAsync<Login>,
        IRepositoryReader<Login>,
        IRepositoryReaderAsync<Login> { }
}
