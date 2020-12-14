using PhotoSharingApp.Web.Extensions;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApp.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ValueReporterAttribute());
        }
    }
}
