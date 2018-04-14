using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class SubmissionsController : Controller
    {
        // GET: Submissions
        public ActionResult Index()
        {
            return View();
        }
    }
}