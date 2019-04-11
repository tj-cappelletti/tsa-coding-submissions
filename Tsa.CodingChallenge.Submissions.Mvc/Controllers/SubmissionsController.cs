using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class SubmissionsController : MvcControllerBase
    {
        public SubmissionsController(SubmissionsEntitiesContext entitiesContext) : base(entitiesContext) { }

        public IActionResult Index([FromQuery(Name = "teamLogin")]string teamLogin)
        {
            IQueryable<Submission> submissions = EntitiesContext.Submissions;

            if (!string.IsNullOrWhiteSpace(teamLogin))
            {
                submissions = submissions.Where(s => s.Login.Identity == teamLogin);
            }

            return View(submissions.Select(s => new SubmissionViewModel
            {
                EvaluateDateTime = s.EvaluatedDateTime,
                Id = s.Id,
                LoginIdentity = s.Login.Identity,
                ProblemName = s.Problem.Name,
                ProgrammingLanguage = s.ProgrammingLanguage,
                ProgrammingLanguageFlags = string.Empty,
                SubmissionDateTime = s.SubmissionDateTime
            }).OrderBy(s => s.SubmissionDateTime).ToList());
        }

        public FileResult Download(int id)
        {
            var submission = EntitiesContext.Submissions.Single(s => s.Id == id);

            return File(submission.RawFile, "application/text", submission.FileName);
        }
    }
}