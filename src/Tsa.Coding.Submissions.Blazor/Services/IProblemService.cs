using System.Collections.Generic;
using System.Threading.Tasks;
using Tsa.Coding.Submissions.Core.Models;

namespace Tsa.Coding.Submissions.Blazor.Services
{
    public interface IProblemService
    {
        Task<ProblemModel> Get(int id);

        Task<IEnumerable<ProblemModel>> Get();
    }
}
