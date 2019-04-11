using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Core.Queues;
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
            if (solutionSubmitted.HasValue && solutionSubmitted.Value) TempData.Add("solutionSubmitted", true);

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
            var submissionViewModel = new SubmissionUploadViewModel
            {
                ProblemName = EntitiesContext.Problems.Single(p => p.Id == id).Name
            };

            return View(submissionViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Submission(int id, SubmissionUploadViewModel submissionUploadViewModel)
        {
            var problemId = id;
            var rawFile = new byte[submissionUploadViewModel.FileUpload.Length];
            var fileStream = submissionUploadViewModel.FileUpload.OpenReadStream();
            fileStream.Read(rawFile, 0, rawFile.Length);

            var submission = new Submission
            {
                FileName = submissionUploadViewModel.FileUpload.FileName,
                LoginId = int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value),
                ProblemId = problemId,
                ProgrammingLanguage = submissionUploadViewModel.ProgrammingLanguage,
                RawFile = rawFile,
                SubmissionDateTime = DateTime.Now
            };

            EntitiesContext.Submissions.Add(submission);
            EntitiesContext.SaveChanges();

            //var connectionFactory = new ConnectionFactory
            //{
            //    Uri = new Uri("amqp://guest:guest@rabbitmq:5672")
            //};

            //using (var connection = connectionFactory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    const string exchange = "tsa-coding-challenge";
            //    const string routingKey = "tsa";
            //    string queue;

            //    switch (submissionUploadViewModel.ProgrammingLanguage)
            //    {
            //        case ProgrammingLanguage.C:
            //            queue = QueueNames.C;
            //            break;
            //        case ProgrammingLanguage.CPlusPlus:
            //            queue = QueueNames.CPlusPlus;
            //            break;
            //        case ProgrammingLanguage.CSharp:
            //            queue = QueueNames.CSharp;
            //            break;
            //        case ProgrammingLanguage.FSharp:
            //            queue = QueueNames.FSharp;
            //            break;
            //        case ProgrammingLanguage.Java:
            //            queue = QueueNames.Java;
            //            break;
            //        case ProgrammingLanguage.NodeJs:
            //            queue = QueueNames.NodeJs;
            //            break;
            //        case ProgrammingLanguage.Perl:
            //            queue = QueueNames.Perl;
            //            break;
            //        case ProgrammingLanguage.Python:
            //            queue = QueueNames.Python;
            //            break;
            //        case ProgrammingLanguage.Ruby:
            //            queue = QueueNames.Ruby;
            //            break;
            //        case ProgrammingLanguage.VbDotNet:
            //            queue = QueueNames.VbDotNet;
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }

            //    channel.ExchangeDeclare(exchange, ExchangeType.Direct);
            //    channel.QueueDeclare(queue, false, false, false, null);
            //    channel.QueueBind(queue, exchange, routingKey, null);

            //    var encodedFile = Convert.ToBase64String(rawFile, 0, rawFile.Length);

            //    var message = JsonConvert.SerializeObject(new { submissionId = submission.Id, problemId, fileName = submission.FileName, file = encodedFile });
            //    var body = Encoding.UTF8.GetBytes(message);

            //    channel.BasicPublish(exchange, routingKey, null, body);
            //}

            return RedirectToAction("Index", new { solutionSubmitted = true });
        }
    }
}