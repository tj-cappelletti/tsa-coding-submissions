using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Core.Security;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class AccountController : MvcControllerBase
    {
        private const string DuplicateTeamMemberNumber = "The team member's number must unique.";
        private const string GenericLoginError = "Invalid username or password.";
        private const string SchoolNumbersMismatchErrorMessage = "The team member's school number does not match the team's school number.";
        private const string TeamIdentityIsTeamMemberIdentityErrorMessage = "The team member's number cannot be the same as the team's number.";

        public AccountController(SubmissionsEntitiesContext submissionsEntitiesContext) : base(submissionsEntitiesContext) { }

        [Authorize]
        public IActionResult Details()
        {
            var loginDetailsViewModel = (from logins in EntitiesContext.Logins
                                         where logins.Identity == User.Identity.Name
                                         select new LoginDetailsViewModel
                                         {
                                             Id = logins.Id,
                                             Identity = logins.Identity,
                                             Role = logins.Role.ToString()
                                         }).Single();

            if (User.IsInRole(Role.Student.ToString()))
            {
                var index = 0;
                var teamMembers = EntitiesContext.TeamMembers.Where(tm => tm.LoginId == loginDetailsViewModel.Id).ToList();

                foreach (var teamMember in teamMembers)
                {
                    if (index == 0)
                        loginDetailsViewModel.TeamMember1 = teamMember.MemberId;
                    else if (index == 1)
                        loginDetailsViewModel.TeamMember2 = teamMember.MemberId;
                    else if (index == 2)
                        loginDetailsViewModel.TeamMember3 = teamMember.MemberId;
                    else
                        break;

                    index++;
                }
            }

            return View(loginDetailsViewModel);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var login = EntitiesContext.Logins.SingleOrDefault(l => l.Identity == model.Identity);

            if (login == null)
            {
                ModelState.AddModelError(string.Empty, GenericLoginError);
                return View(model);
            }

            if (!PasswordStorage.VerifyPassword(model.Password, login.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, GenericLoginError);
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                new Claim(ClaimTypes.Name, login.Identity),
                new Claim(ClaimTypes.NameIdentifier, login.Identity),
                new Claim(ClaimTypes.Role, login.Role.ToString()),
                new Claim(ClaimTypes.Sid, login.Id.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal);

            return returnUrl == string.Empty
                ? RedirectToAction("Summary", "Home")
                : RedirectToUrl(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

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

            EntitiesContext.Logins.Add(login);

            var teamMember1 = new TeamMember
            {
                Login = login,
                MemberId = model.TeamMember1
            };

            EntitiesContext.TeamMembers.Add(teamMember1);

            if (!string.IsNullOrWhiteSpace(model.TeamMember2))
            {
                var teamMember2 = new TeamMember
                {
                    Login = login,
                    MemberId = model.TeamMember2
                };

                EntitiesContext.TeamMembers.Add(teamMember2);
            }

            if (!string.IsNullOrWhiteSpace(model.TeamMember3))
            {
                var teamMember3 = new TeamMember
                {
                    Login = login,
                    MemberId = model.TeamMember3
                };

                EntitiesContext.TeamMembers.Add(teamMember3);
            }

            EntitiesContext.SaveChanges();

            return RedirectToAction("Login", "Account");
        }
    }
}