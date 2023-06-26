using System.Web;
using System.Web.Mvc;

namespace Udemy_MVC5Course
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
