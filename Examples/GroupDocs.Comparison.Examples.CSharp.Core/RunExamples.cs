using GroupDocs.Comparison.Examples.CSharp.AdvancedUsage;
using GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading;
using GroupDocs.Comparison.Examples.CSharp.BasicUsage;
using GroupDocs.Comparison.Examples.CSharp.QuickStart;
using System;
using GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class RunExamples
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open RunExamples.cs. \nIn Main() method uncomment the example that you want to run.");
            Console.WriteLine("=====================================================");

            //NOTE: Please uncomment the example you want to try out
            #region Quick Start
            SetLicenseFromFile.Run();
            //SetLicenseFromStream.Run();
            //SetMeteredLicense.Run();
            HelloWorld.Run();
            #endregion

            #region Get supported file formats
            GetSupportedFormats.Run();
            #endregion

            #region Get document info
            GetDocumentInfoPath.Run();
            #endregion

            #region Get document info
            GetDocumentInfoStream.Run();
            #endregion

            #region Compare cells files from path
            CompareCellsFromPath.Run();
            #endregion

            #region Compare cells files from stream
            CompareCellsFromStream.Run();
            #endregion

            #region Compare documents from path
            CompareDocumentsFromPath.Run();
            #endregion

            #region Compare documents from stream
            CompareDocumentsFromStream.Run();
            #endregion

            #region Compare image from path without SummaryPage
            CompareImageFromPath.Run();
            #endregion

            #region Compare image from stream without SummaryPage
            CompareImageFromStream.Run();
            #endregion

            #region Compare documents from path with customized change styles from path
            UseCompareOptions.CustomizeChangesStylesPath();
            #endregion

            #region Compare documents from path with customized change styles from stream
            UseCompareOptions.CustomizeChangesStylesStream();
            #endregion

            #region Compare documents from stream with some settings 
            CompareDocumentsSettingsStream.Run();
            #endregion

            #region Compare documents with passwords from path
            CompareDocumentsProtectedPath.Run();
            #endregion

            #region Compare documents with passwords from stream
            CompareDocumentsProtectedPath.Run();
            #endregion

            #region Get list of changes from path
            GetChanges.GetListOfChangesPath();
            #endregion

            #region Get list of changes from stream
            GetChanges.GetListOfChangesStream();
            #endregion

            #region Update changes from path
            AcceptRejectDetectedChangesPath.Run();
            #endregion

            #region Update changes from stream
            AcceptRejectDetectedChangesStream.Run();
            #endregion

            #region Multicompare documents from path
            CompareMultipleDocumentsPath.CompareMultipleWordsDocuments();
            #endregion

            #region Multicompare documents from stream
            CompareMultipleDocumentsStream.Run();
            #endregion

            #region Multicompare protected documents from path
            CompareMultipleDocumentsProtectedPath.Run();
            #endregion

            #region Multicompare protected documents from stream
            CompareMultipleDocumentsProtectedStream.Run();
            #endregion

            #region Multicompare documents with settings from stream
            CompareMultipleDocumentsSettingsStream.Run();
            #endregion

            #region Multicompare documents with settings from path
            CompareMultipleDocumentsSettingsPath.Run();
            #endregion

            #region Preview document pages for source document
            GetPagePreviewsForSourceDocument.Run();
            #endregion

            #region Preview document pages for target document
            GetPagePreviewsForTargetDocument.Run();
            #endregion

            #region Preview document pages for resultant document
            GetPagePreviewsForResultantDocument.Run();
            #endregion

            #region Preview document page specific image size
            SetSpecificImagesSize.Run();
            #endregion

            #region Calculate coordinates
            GetChanges.GetChangesCoordinates();
            #endregion

            #region Metered credits
            //GetMeteredCreditsLimit.Run();
            #endregion

            #region Using page preview release stream delegate
            GetPagePreviewsResouresCleaning.Run();
            #endregion

            #region Using sensitivity option
            UseCompareOptions.AdjustComparisonSensitivity();
            #endregion

            #region Using SaveOptions target metadata
            SetDocumentMetadataTarget.Run();
            #endregion

            #region Using SaveOptions source metadata
            SetDocumentMetadataSource.Run();
            #endregion

            #region Using SaveOptions user metadata
            SetDocumentMetadataUserDefined.Run();
            #endregion

            #region Protect result document
            SetPasswordForResultantDocument.Run();
            #endregion

            #region Load documents from stream
            LoadDocumentFromLocalDisc.Run();
            #endregion

            #region Load documents from path
            LoadDocumentFromStream.Run();
            #endregion

            #region Multi compare for txt
            CompareMultipleDocumentsPath.CompareMultipleTxtDocuments();
            #endregion

            #region Multi compare for email
            CompareMultipleDocumentsPath.CompareMultipleEmailDocuments();
            #endregion

            #region Multi compare for pdf
            CompareMultipleDocumentsPath.CompareMultiplePdfDocuments();
            #endregion

            #region Multi compare for diagram
            CompareMultipleDocumentsPath.CompareMultipleDiagramDocuments();
            #endregion

            #region Ignore Header/Footer
            UseCompareOptions.IgnoreHeaderFooter();
            #endregion

            #region Set output paper size
            UseCompareOptions.SetOutputPaperSize();
            #endregion

            #region Get target text from changed range
            GetChanges.GetTargetText();
            #endregion

            #region Compare document properties
            UseCompareOptions.CompareDocumentProperties();
            #endregion

            #region Compare bookmarks
            UseCompareOptions.CompareBookmarks();
            #endregion

            #region Compare documents with setting - ShowOnlySummaryPage
            UseCompareOptions.GetOnlySummaryPage();
            #endregion

            #region Compare documents with setting - ExtendedSummaryPage
            UseCompareOptions.GetExtendedSummaryPage();
            #endregion

            #region Accept or Reject detected revisions from path
            AcceptRejectRevisions.AcceptRejectRevisionsFromPath();
            #endregion

            #region Accept or Reject detected revisions from stream
            AcceptRejectRevisions.AcceptRejectRevisionsFromStream();
            #endregion

            #region Load custom font for comparison
            UseLoadOptions.LoadCustomFonts();
            #endregion

            Console.WriteLine();
            Console.WriteLine("All done.");
            Console.ReadKey();
        }
    }
}
