using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupDocs.Comparison.Live.Demos.UI.ComparisonApp
{
	public partial class Default : System.Web.UI.Page
	{
		public string fileName = "";
		public string fileName2 = "";
		public string productName = "";
		public string featureName = "";
		public string folderName = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Page.RouteData.Values["sourcefilename"] != null)
				{
					fileName = Page.RouteData.Values["sourcefilename"].ToString();
				}
				if (Page.RouteData.Values["targetfilename"] != null)
				{
					fileName2 = Page.RouteData.Values["targetfilename"].ToString();
				}
				if (Page.RouteData.Values["Product"] != null)
				{
					productName = Page.RouteData.Values["Product"].ToString();
				}
				if (Page.RouteData.Values["feature"] != null)
				{
					featureName = Page.RouteData.Values["feature"].ToString();
				}
				if (Page.RouteData.Values["foldername"] != null)
				{
					folderName = Page.RouteData.Values["foldername"].ToString();
				}
			}
		}
	}
}