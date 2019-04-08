using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class SubmissionsApiController : ApiControllerBase
    {
        public SubmissionsApiController(SubmissionsEntitiesContext submissionsEntitiesContext) : base(submissionsEntitiesContext) { }
    }
}