using System.Web;
using System.Web.Mvc;

namespace Diplomado_MVC_UASD_Estudiante_ImageUpload
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
