using Tsa.CodingChallenge.Submissions.Core.Entities;

namespace Tsa.CodingChallenge.Submissions.Core.Repositories
{
    public interface ILoginRepository : IRepositoryModifier<Login>,
        IRepositoryModifierAsync<Login>,
        IRepositoryReader<Login>,
        IRepositoryReaderAsync<Login> { }
}