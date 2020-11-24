using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tsa.CodingChallenge.Submissions.Mvc.Models;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }

        [Authorize]
        public IActionResult Summary()
        {
            return View();
        }
    }
}