using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Tsa.CodingChallenge.Submissions.Business.Persistence;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public int SystemUserId => 0;

        public IUnitOfWork UnitOfWork { get; }

        public BaseController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected ActionResult RedirectToUrl(string url)
        {
            if (Url.IsLocalUrl(url)) return Redirect(url);

            return RedirectToAction("Index", "Account");
        }
    }
}