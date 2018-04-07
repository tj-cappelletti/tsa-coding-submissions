using System.Web.Mvc;
using Tsa.CodingChallenge.Submissions.Business.Persistence;

namespace Tsa.CodingChallenge.Submissions.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IUnitOfWork unitOfWork) { UnitOfWork = unitOfWork; }

        public int SystemUserId => 0;

        public IUnitOfWork UnitOfWork { get; }
    }
}