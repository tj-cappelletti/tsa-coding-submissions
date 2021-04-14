using System.Collections.Generic;
using System.Threading.Tasks;
using Tsa.Coding.Submissions.Core.Models;

namespace Tsa.Coding.Submissions.WebApi.Repositories
{
    public interface IProblemRepository
    {
        Task<ProblemModel> CreateAsync(ProblemModel problem);

        Task<IEnumerable<ProblemModel>> GetAsync();

        Task<ProblemModel> GetAsync(int id);

        Task<ProblemModel> UpdateAsync(ProblemModel problem);
    }
}
