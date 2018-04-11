using System.Linq;
using System.Web.Mvc;
using Tsa.CodingChallenge.Submissions.Business.Persistence;
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
                                    select new ProblemsViewModel
                                    {
                                        Description = problems.Description,
                                        Id = problems.Id,
                                        Identifier = problems.Identifier,
                                        Name = problems.Name
                                    }).Single();

            return View(problemViewModel);
        }

        [Authorize]
        public ActionResult Index()
        {
            var problemsViewModel = (from problems in UnitOfWork.ProblemsRepository
                                     select new ProblemsViewModel
                                     {
                                         Id = problems.Id,
                                         Identifier = problems.Identifier,
                                         Name = problems.Name
                                     }).ToList();

            return View(problemsViewModel);
        }
    }
}