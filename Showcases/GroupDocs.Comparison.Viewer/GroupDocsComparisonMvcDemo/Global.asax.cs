using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GroupDocs.Comparison.Common.License;

namespace GroupDocsComparisonMvcDemo
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Register areas
            AreaRegistration.RegisterAllAreas();

            //Set license
            License license = new License();
            license.SetLicense(@".\..\..\licenses\GroupDocs.Comparison.lic");

            //Register filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Create comparison settings
            var comparisonSettings = new ComparisonWidgetSettings
            {
                //Set root storage path
                RootStoragePath = Server.MapPath("~/App_Data/"),
                //Set comparison behavior
                ComparisonBehavior =
                {
                    StyleChangeDetection = true,
                    GenerateSummaryPage = true
                },
                //Set license for Viewer
                LicensePath = @".\..\..\licenses\GroupDocs.Viewer.lic"
            };

            //Initiate comparison widget
            ComparisonWidget.Init(comparisonSettings);
            //Register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes, comparisonSettings);
            //Bundle scripts
            BundleConfigurator.Configure(comparisonSettings);
        }
    }
}