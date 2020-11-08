using System.Web;
using System.Web.Mvc;

namespace ePortfolio_30080193
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
