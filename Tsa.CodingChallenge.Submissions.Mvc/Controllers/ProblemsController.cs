using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Azure.ServiceBus;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Core.Persistence;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class ProblemsController : BaseController
    {
        public ProblemsController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [Authorize]
        public ActionResult Details(int id)
        {
            var problemViewModel = (from problems in UnitOfWork.ProblemsRepository
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

            var problemsViewModel = (from problems in UnitOfWork.ProblemsRepository
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
                ProblemName = UnitOfWork.ProblemsRepository.Single(p => p.Id == id).Name
            };

            return View(submissionViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Submission(SubmissionViewModel submissionViewModel)
        {
            var problemId = int.Parse((string)Url.RequestContext.RouteData.Values["id"]);

            var rawFile = new byte[submissionViewModel.FileUpload.InputStream.Length];
            submissionViewModel.FileUpload.InputStream.Read(rawFile, 0, rawFile.Length);

            var submission = new Submission
            {
                FileName = submissionViewModel.FileUpload.FileName,
                LoginId = int.Parse(AuthenticationManager.User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value),
                ProblemId = problemId,
                ProgrammingLanguage = submissionViewModel.ProgrammingLanguage,
                RawFile = rawFile,
                SubmissionDateTime = DateTime.Now
            };

            UnitOfWork.SubmissionsRepository.Add(submission);
            UnitOfWork.SaveChanges();

            var connectionString = ConfigurationManager.ConnectionStrings["SubmissionsServiceBus"].ConnectionString;
            string queue;

            switch (submissionViewModel.ProgrammingLanguage)
            {
                case ProgrammingLanguage.DotNet:
                    queue = ConfigurationManager.AppSettings["DotNetQueue"];
                    break;
                case ProgrammingLanguage.C:
                case ProgrammingLanguage.Java:
                case ProgrammingLanguage.NodeJs:
                case ProgrammingLanguage.Perl:
                case ProgrammingLanguage.Python:
                case ProgrammingLanguage.Ruby:
                default:
                    throw new NotImplementedException();
            }

            var message = new Message(BitConverter.GetBytes(submission.Id));

            var queueClient = new QueueClient(connectionString, queue);
            await queueClient.SendAsync(message);

            return RedirectToAction("Index", new { solutionSubmitted = true });
        }
    }
}