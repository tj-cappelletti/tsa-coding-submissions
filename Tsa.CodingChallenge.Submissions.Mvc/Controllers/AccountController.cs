using System.Web.Mvc;
using FinancialPlanner.Core.Security;
using Tsa.CodingChallenge.Submissions.Business.Entities;
using Tsa.CodingChallenge.Submissions.Business.Persistence;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        // GET: Account
        public ActionResult Index() { return View(); }

        [AllowAnonymous]
        public ActionResult Registration() { return View(); }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var login = new Login
            {
                Identity = model.Identity,
                PasswordHash = PasswordStorage.CreateHash(model.Password),
                Role = Role.Student,
                RoleId = (int) Role.Student
            };


            UnitOfWork.LoginsRepository.Add(login);
            UnitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}