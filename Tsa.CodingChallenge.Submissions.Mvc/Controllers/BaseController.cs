using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Tsa.CodingChallenge.Submissions.Business.Persistence;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public BaseController(IUnitOfWork unitOfWork) { UnitOfWork = unitOfWork; }

        public int SystemUserId => 0;

        public IUnitOfWork UnitOfWork { get; }
    }
}