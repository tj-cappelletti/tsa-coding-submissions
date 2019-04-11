using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class SubmissionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}