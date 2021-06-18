using System.Web.Mvc;

namespace GroupDocs.Comparison.MVC.Controllers
{
    /// <summary>
    /// Comparison Web page controller
    /// </summary>
    public class ComparisonController : Controller
    {
        // View Comparison
        public ActionResult Index()
        {
            return View();
        }
    }
}