using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        public SubmissionsEntitiesContext EntitiesContext { get; }

        public ApiControllerBase(SubmissionsEntitiesContext entitiesContext)
        {
            EntitiesContext = entitiesContext;
        }
    }
}