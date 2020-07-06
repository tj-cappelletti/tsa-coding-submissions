using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Core.Repositories;
using Tsa.CodingChallenge.Submissions.Core.Security;
using Tsa.CodingChallenge.Submissions.WebApi.Model;

namespace Tsa.CodingChallenge.Submissions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public AccountsController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<IActionResult> Register([FromBody] LoginModel loginModel)
        {
            var login = new Login
            {
                Identity = loginModel.Identity,
                PasswordHash = PasswordStorage.CreateHash(loginModel.Password),
                Role = Role.Student
            };

            foreach (var teamMemberModel in loginModel.TeamMembers)
            {
                login.TeamMembers.Add(new TeamMember
                {
                    Login = login,
                    MemberId = teamMemberModel.MemberId
                });
            }

            var createdLogin = await _loginRepository.AddAsync(login);

            return Ok(new LoginModel
            {
                Id = loginModel.Id,
                Identity =createdLogin.Identity,
                PasswordHash = createdLogin.PasswordHash,
                RoleId = (int)createdLogin.Role,
            });
        }
    }
}
