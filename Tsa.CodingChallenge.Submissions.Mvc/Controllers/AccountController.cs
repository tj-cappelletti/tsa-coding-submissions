using System.Web.Mvc;
using FinancialPlanner.Core.Security;
using Tsa.CodingChallenge.Submissions.Business.Entities;
using Tsa.CodingChallenge.Submissions.Business.Persistence;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        private const string SchoolNumbersMismatchErrorMessage = "The team member's school number does not match the team's school number.";
        private const string DuplicateTeamMemberNumber = "The team member's number must unique.";
        private const string TeamIdentityIsTeamMemberIdentityErrorMessage = "The team member's number cannot be the same as the team's number.";

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

            var detailedModelStateIsValid = true;

            var schoolId = model.Identity.Substring(0, 4);

            if (model.Identity == model.TeamMember1)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember1), TeamIdentityIsTeamMemberIdentityErrorMessage);
            }
            else if (model.TeamMember1.Substring(0, 4) != schoolId)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember1), SchoolNumbersMismatchErrorMessage);
            }

            if (model.Identity == model.TeamMember2)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember2), SchoolNumbersMismatchErrorMessage);
            }
            else if (model.TeamMember1 == model.TeamMember2)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember3), DuplicateTeamMemberNumber);
            }
            else if (model.TeamMember2 != null && model.TeamMember2.Substring(0, 4) != schoolId)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember2), SchoolNumbersMismatchErrorMessage);
            }

            if (model.Identity == model.TeamMember3)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember3), SchoolNumbersMismatchErrorMessage);
            }
            else if (model.TeamMember1 == model.TeamMember3 || model.TeamMember2 == model.TeamMember3)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember3), DuplicateTeamMemberNumber);
            }
            else if (model.TeamMember3 != null && model.TeamMember3.Substring(0, 4) != schoolId)
            {
                detailedModelStateIsValid = false;
                ModelState.AddModelError(nameof(model.TeamMember3), SchoolNumbersMismatchErrorMessage);
            }

            if (!detailedModelStateIsValid) return View(model);

            var login = new Login
            {
                Identity = model.Identity,
                PasswordHash = PasswordStorage.CreateHash(model.Password),
                Role = Role.Student
            };

            UnitOfWork.LoginsRepository.Add(login);

            var teamMember1 = new TeamMember
            {
                Login = login,
                MemberId = model.TeamMember1
            };

            UnitOfWork.TeamMembersRepository.Add(teamMember1);

            if (!string.IsNullOrWhiteSpace(model.TeamMember2))
            {
                var teamMember2 = new TeamMember
                {
                    Login = login,
                    MemberId = model.TeamMember2
                };

                UnitOfWork.TeamMembersRepository.Add(teamMember2);
            }

            if (!string.IsNullOrWhiteSpace(model.TeamMember3))
            {
                var teamMember3 = new TeamMember
                {
                    Login = login,
                    MemberId = model.TeamMember3
                };

                UnitOfWork.TeamMembersRepository.Add(teamMember3);
            }

            UnitOfWork.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}