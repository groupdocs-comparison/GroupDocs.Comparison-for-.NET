//ExStart:PresentationDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Cells.Contracts.Nodes;
using GroupDocs.Comparison.Cells.Nodes;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class WorkBookDcumentsComparision
    {
        //ExStart:CompareWorkBooksFromStreamToFile
        /// <summary>
        /// Compare two WorkBooks from streams with saving results into a file
        /// </summary>
        public static void CompareWorkBooksFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareWorkBooksFromStreamToFile

        //ExStart:CompareWorkBooksFromPathToFile
        /// <summary>
        /// Compare two WorkBooks from file path with saving results into a file
        /// </summary>
        public static void CompareWorkBooksFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells);
        }
        //ExEnd:CompareWorkBooksFromPathToFile

        //ExStart:CompareWorkBooksFromStreamToFileWithSettings
        /// <summary>
        /// Compare two WorkBooks from streams with saving results into a file with documen settings
        /// </summary>
        public static void CompareWorkBooksFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells, new CellsComparisonSettings());

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareWorkBooksFromStreamToFileWithSettings

        //ExStart:CompareWorkBooksFromPathToFileWithSettings
        /// <summary>
        /// Compare two WorkBooks from file path with saving results into a file with document settings
        /// </summary>
        public static void CompareWorkBooksFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells, new CellsComparisonSettings());
        }
        //ExEnd:CompareWorkBooksFromPathToFileWithSettings
    }
}
//ExEnd:WorkBookDcumentsComparisionClass