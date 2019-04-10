using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Model;

namespace Tsa.CodingChallenge.Submissions.Mvc.Models
{
    public static class ModelFactory
    {
        public static TestDataSetModel CreateModel(TestDataSet entity)
        {
            return new TestDataSetModel
            {
                Data = entity.Data,
                DisplayWithProblem = entity.DisplayWithProblem,
                ExpectedResult = entity.ExpectedResult,
                Id = entity.Id,
                Identifier = entity.Identifier,
                ProblemId = entity.ProblemId,
                Sequence = entity.Sequence
            };
        }
    }
}