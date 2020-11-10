using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.Entities;
using Tsa.CodingChallenge.Submissions.Core.Repositories;
using Tsa.CodingChallenge.Submissions.Core.Security;
using Tsa.CodingChallenge.Submissions.WebApi.Model;
using Tsa.CodingChallenge.Submissions.WebApi.Responses;

namespace Tsa.CodingChallenge.Submissions.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IPasswordStorage _passwordStorage;

        public AccountsController(ILoginRepository loginRepository, IPasswordStorage passwordStorage)
        {
            _loginRepository = loginRepository;
            _passwordStorage = passwordStorage;
        }

        private static LoginModel CreateLoginModel(Login login)
        {
            var loginModel = new LoginModel
            {
                Id = login.Id,
                Identity = login.Identity,
                PasswordHash = login.PasswordHash,
                RoleId = (int)login.Role
            };

            foreach (var teamMember in login.TeamMembers)
                loginModel.TeamMembers.Add(new TeamMemberModel
                {
                    Id = teamMember.Id,
                    LoginId = teamMember.LoginId,
                    MemberId = teamMember.MemberId
                });

            return loginModel;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            //TODO: Implement a better error response
            if (loginModel == null) return BadRequest();

            var login = await _loginRepository.SingleOrDefaultAsync(l => l.Id == loginModel.Id);

            if (login == null) return NotFound();

            if (_passwordStorage.VerifyPassword(loginModel.Password, login.PasswordHash)) return Ok(CreateLoginModel(login));

            return new NotAcceptableResult();
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody]LoginModel loginModel)
        {
            var login = new Login
            {
                Identity = loginModel.Identity,
                PasswordHash = _passwordStorage.CreateHash(loginModel.Password),
                Role = Role.Student
            };

            foreach (var teamMemberModel in loginModel.TeamMembers)
                login.TeamMembers.Add(new TeamMember
                {
                    Login = login,
                    MemberId = teamMemberModel.MemberId
                });

            var createdLogin = await _loginRepository.AddAsync(login);

            return Created("api/accounts/register", CreateLoginModel(createdLogin));
        }
    }
}