using System.Web.Mvc;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }
    }
}