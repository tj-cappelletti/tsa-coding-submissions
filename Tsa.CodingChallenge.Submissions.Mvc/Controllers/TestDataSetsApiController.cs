using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    [Produces("application/json")]
    [Route("api/testdatasets")]
    public class TestDataSetsApiController : ApiControllerBase
    {
        public TestDataSetsApiController(SubmissionsEntitiesContext submissionsEntitiesContext) : base(submissionsEntitiesContext) { }

        [HttpGet]
        public async Task<ActionResult<List<TestDataSet>>> GetAll([FromQuery(Name = "problemId")] int problemId)
        {
            IQueryable<TestDataSet> testDataSets = EntitiesContext.TestDataSets;

            if (problemId != 0)
            {
                testDataSets = testDataSets.Where(tds => tds.ProblemId == problemId);
            }

            return await testDataSets.ToListAsync();
        }
    }
}