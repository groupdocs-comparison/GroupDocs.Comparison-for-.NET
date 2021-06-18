using GroupDocs.Comparison.WebForms.Products.Common.Entity.Web;
using GroupDocs.Comparison.WebForms.Products.Comparison.Model.Request;
using GroupDocs.Comparison.WebForms.Products.Comparison.Model.Response;
using System.Collections.Generic;

namespace GroupDocs.Comparison.WebForms.Products.Comparison.Service
{
    public interface IComparisonService
    {

        List<FileDescriptionEntity> LoadFiles(PostedDataEntity fileTreeRequest);

        /// <summary>
        /// Compare two documents, save results in files
        /// </summary>
        /// <param name="compareRequest">PostedDataEntity</param>
        /// <returns>CompareResultResponse</returns>
        CompareResultResponse Compare(CompareRequest compareRequest);

        /// <summary>
        ///  Load document page as images
        /// </summary>
        /// <param name="postedData">PostedDataEntity</param>
        /// <returns>LoadDocumentEntity</returns>
        PageDescriptionEntity LoadDocumentPage(PostedDataEntity postedData);

        /// <summary>
        /// Check format files for comparing
        /// </summary>
        /// <param name="file">CompareRequest</param>
        /// <returns>bool</returns>
        bool CheckFiles(CompareRequest files);       
    }
}