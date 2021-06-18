using GroupDocs.Comparison.MVC.Products.Common.Entity.Web;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Comparison.MVC.Products.Comparison.Model.Request
{
    public class CompareRequest
    {
        /// <summary>
        /// Contains list of the documents paths
        /// </summary>
        public List<CompareFileDataRequest> guids { get; set; }
    }
}