using System.Web;
using System.Web.Mvc;

namespace Practica5_2DesarrolloWebUASD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
