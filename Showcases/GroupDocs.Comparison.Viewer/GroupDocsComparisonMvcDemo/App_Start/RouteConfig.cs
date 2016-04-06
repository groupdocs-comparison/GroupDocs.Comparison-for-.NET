using System.Web.Mvc;
using System.Web.Routing;

namespace GroupDocsComparisonMvcDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, ComparisonWidgetSettings settings)
        {
            //Add route "{resource}.axd/{*pathInfo}" to ignore
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Init Viewer routes
            routes.MapRoute(
                name: "document-viewer",
                url: "document-viewer/{action}/{id}",
                defaults: new { controller = "Viewer", action = "Index", id = UrlParameter.Optional }
            );
            //Init Comparison routes
            routes.MapRoute(null, settings.ClientFilesPrefix + "/embedded/{*path}", new { controller = "Comparison", action = "GetResource" });

            routes.MapRoute(null, settings.ClientFilesPrefix + "/comparison2/updatechanges", new { controller = "Comparison", action = "ApplyChanges" });
            routes.MapRoute(null, settings.ClientFilesPrefix + "/comparison2/getchanges", new { controller = "Comparison", action = "GetChanges" });

            //Add default route for Home controller
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}