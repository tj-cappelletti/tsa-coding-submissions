using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Core.DataContexts;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class MvcControllerBase : Controller
    {
        public SubmissionsEntitiesContext EntitiesContext { get; }

        public MvcControllerBase(SubmissionsEntitiesContext entitiesContext)
        {
            EntitiesContext = entitiesContext;
        }

        protected ActionResult RedirectToUrl(string url)
        {
            if (Url.IsLocalUrl(url)) return Redirect(url);

            return RedirectToAction("Index", "Account");
        }
    }
}