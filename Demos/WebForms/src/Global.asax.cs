using System;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using GroupDocs.Comparison.WebForms.AppDomainGenerator;

namespace GroupDocs.Comparison.WebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Fix required to use several GroupDocs products in one project.
            // Set GroupDocs products assemblies names           
            string comparisonAssemblyName = "GroupDocs.Comparison.dll";           
            // set GroupDocs.Comparison license
            DomainGenerator comparisonDomainGenerator = new DomainGenerator(comparisonAssemblyName, "GroupDocs.Comparison.License");
            comparisonDomainGenerator.SetComparisonLicense(comparisonDomainGenerator.CurrentType);

            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}