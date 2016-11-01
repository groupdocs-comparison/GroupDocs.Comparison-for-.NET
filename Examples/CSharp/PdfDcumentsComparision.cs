//ExStart:PdfDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Pdf;
using GroupDocs.Comparison.Pdf.Contracts.ComparedResult;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class PdfDcumentsComparision
    {
        //ExStart:ComparePdfFromStreamToFile
        /// <summary>
        /// Compare two Pdf from streams with saving results into a file
        /// </summary>
        public static void ComparePdfFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:ComparePdfFromStreamToFile

        //ExStart:ComparePdfFromPathToFile
        /// <summary>
        /// Compare two Pdf from file path with saving results into a file
        /// </summary>
        public static void ComparePdfFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf);
        }
        //ExEnd:ComparePdfFromPathToFile

        //ExStart:ComparePdfFromStreamToFileWithSettings
        /// <summary>
        /// Compare two Pdf from streams with saving results into a file with documen settings
        /// </summary>
        public static void ComparePdfFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf, new PdfComparisonSettings());

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:ComparePdfFromStreamToFileWithSettings

        //ExStart:ComparePdfFromPathToFileWithSettings
        /// <summary>
        /// Compare two Pdf from file path with saving results into a file with document settings
        /// </summary>
        public static void ComparePdfFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf, new PdfComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, GenerateSummaryPage = true, MovedContentDetection=true,  });
        }
        //ExEnd:ComparePdfFromPathToFileWithSettings
    }
}
//ExEnd:PdfDcumentsComparisionClass