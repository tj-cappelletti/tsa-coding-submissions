using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class ProblemsController : MvcControllerBase
    {
        public ProblemsController(SubmissionsEntitiesContext submissionsEntitiesContext) : base(submissionsEntitiesContext) { }

        [Authorize]
        public ActionResult Details(int id)
        {
            var problemViewModel = (from problems in EntitiesContext.Problems
                                    where problems.Id == id
                                    select new ProblemViewModel
                                    {
                                        Description = problems.Description,
                                        Id = problems.Id,
                                        Identifier = problems.Identifier,
                                        Name = problems.Name
                                    }).Single();

            return View(problemViewModel);
        }

        [Authorize]
        public ActionResult Index(bool? solutionSubmitted)
        {
            if (solutionSubmitted.HasValue && solutionSubmitted.Value)
            {
                TempData.Add("solutionSubmitted", true);
            }

            var problemsViewModel = (from problems in EntitiesContext.Problems
                                     select new ProblemViewModel
                                     {
                                         Id = problems.Id,
                                         Identifier = problems.Identifier,
                                         Name = problems.Name
                                     }).ToList();

            return View(problemsViewModel);
        }

        [Authorize]
        public ActionResult Submission(int id)
        {
            var submissionViewModel = new SubmissionViewModel
            {
                ProblemName = EntitiesContext.Problems.Single(p => p.Id == id).Name
            };

            return View(submissionViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Submission(SubmissionViewModel submissionViewModel)
        {
            throw new NotImplementedException();
            //var problemId = int.Parse((string)Url.RequestContext.RouteData.Values["id"]);

            //var rawFile = new byte[submissionViewModel.FileUpload.InputStream.Length];
            //submissionViewModel.FileUpload.InputStream.Read(rawFile, 0, rawFile.Length);

            //var submission = new Submission
            //{
            //    FileName = submissionViewModel.FileUpload.FileName,
            //    LoginId = int.Parse(AuthenticationManager.User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value),
            //    ProblemId = problemId,
            //    ProgrammingLanguage = submissionViewModel.ProgrammingLanguage,
            //    RawFile = rawFile,
            //    SubmissionDateTime = DateTime.Now
            //};

            //UnitOfWork.SubmissionsRepository.Add(submission);
            //UnitOfWork.SaveChanges();

            //var connectionString = ConfigurationManager<>.ConnectionStrings["SubmissionsServiceBus"].ConnectionString;
            //string queue;

            //switch (submissionViewModel.ProgrammingLanguage)
            //{
            //    case ProgrammingLanguage.DotNet:
            //        queue = QueueNames.DotNet;
            //        break;
            //    case ProgrammingLanguage.C:
            //        queue = QueueNames.C;
            //        break;
            //    case ProgrammingLanguage.Java:
            //        queue = QueueNames.Java;
            //        break;
            //    case ProgrammingLanguage.NodeJs:
            //        queue = QueueNames.NodeJs;
            //        break;
            //    case ProgrammingLanguage.Perl:
            //        queue = QueueNames.Perl;
            //        break;
            //    case ProgrammingLanguage.Python:
            //        queue = QueueNames.Python;
            //        break;
            //    case ProgrammingLanguage.Ruby:
            //        queue = QueueNames.Ruby;
            //        break;
            //    default:
            //        throw new NotImplementedException();
            //}

            //var message = new Message(BitConverter.GetBytes(submission.Id))
            //{
            //    ContentType = submission.Id.GetType().FullName,
            //    Label = submission.ProgrammingLanguage.ToString()
            //};

            //var queueClient = new QueueClient(connectionString, queue);
            //await queueClient.SendAsync(message);

            //return RedirectToAction("Index", new { solutionSubmitted = true });
        }
    }
}