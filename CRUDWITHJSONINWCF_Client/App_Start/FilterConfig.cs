using System.Web;
using System.Web.Mvc;

namespace CRUDWITHJSONINWCF_Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
