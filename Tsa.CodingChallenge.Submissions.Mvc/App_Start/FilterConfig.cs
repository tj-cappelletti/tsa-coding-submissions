using System.Web;
using System.Web.Mvc;

namespace Tsa.CodingChallenge.Submissions.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
