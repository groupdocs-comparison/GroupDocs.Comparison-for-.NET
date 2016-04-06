using System.Web.Mvc;

namespace GroupDocsComparisonMvcDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Adding a filter
            filters.Add(new HandleErrorAttribute());
        }
    }
}