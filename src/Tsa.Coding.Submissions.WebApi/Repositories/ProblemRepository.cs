using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tsa.Coding.Submissions.Core.DataContexts;
using Tsa.Coding.Submissions.Core.Entities;
using Tsa.Coding.Submissions.Core.Models;

namespace Tsa.Coding.Submissions.WebApi.Repositories
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly SubmissionsContext _submissionsContext;

        public ProblemRepository(SubmissionsContext submissionsContext)
        {
            _submissionsContext = submissionsContext;
        }

        public Task<ProblemModel> CreateAsync(ProblemModel problem)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProblemModel>> GetAsync()
        {
            var problems = await _submissionsContext.Problems.ToListAsync();

            IEnumerable<ProblemModel> ConvertProblemModels()
            {
                foreach (var problem in problems) yield return ToModel(problem);
            }

            return ConvertProblemModels();
        }

        public async Task<ProblemModel> GetAsync(int id)
        {
            var problem = await _submissionsContext.Problems.SingleOrDefaultAsync(p => p.Id == id);

            return problem != null
                ? ToModel(problem)
                : null;
        }

        private static ProblemModel ToModel(Problem problem)
        {
            return new()
            {
                Description = problem.Description,
                Id = problem.Id,
                Identifier = problem.Identifier,
                Name = problem.Name
            };
        }

        public Task<ProblemModel> UpdateAsync(ProblemModel problem)
        {
            throw new NotImplementedException();
        }
    }
}
