//ExStart:HTMLDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Text;
using GroupDocs.Comparison.Text.Contracts;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class HTMLDcumentsComparision
    {
        //ExStart:CompareHTMLDcumentsFromStreamToFile
        /// <summary>
        /// Compare two HTML documents from streams with saving results into a file
        /// </summary>
        public static void CompareHTMLDcumentsFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile));

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareHTMLDcumentsFromStreamToFile

        //ExStart:CompareHTMLDcumentsFromPathToFile
        /// <summary>
        /// Compare two HTML documents from file path with saving results into a file
        /// </summary>
        public static void CompareHTMLDcumentsFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile));

            // get changes
            GroupDocs.Comparison.Common.Changes.ChangeInfo[] changeInfo = comparison.GetChanges();

            foreach (GroupDocs.Comparison.Common.Changes.ChangeInfo change in changeInfo)
            {
                Console.WriteLine("Tex: " + change.Text);
                // update change with custom HTML
                change.Text = "Added text by update change.";
            }

            Console.WriteLine("apply changes and display updated stream with changes.");
            // update changes
            result = comparison.UpdateChanges(changeInfo, FileType.Html);
        }
        //ExEnd:CompareHTMLDcumentsFromPathToFile

        //ExStart:CompareHTMLDcumentsFromStreamToFileWithSettings
        /// <summary>
        /// Compare two HTML documents from streams with saving results into a file with documen settings
        /// </summary>
        public static void CompareHTMLDcumentsFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), new HtmlComparisonSettings());

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareHTMLDcumentsFromStreamToFileWithSettings

        //ExStart:CompareHTMLDcumentsFromPathToFileWithSettings
        /// <summary>
        /// Compare two HTML documents from file path with saving results into a file with document settings
        /// </summary>
        public static void CompareHTMLDcumentsFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), new HtmlComparisonSettings());
        }
        //ExEnd:CompareHTMLDcumentsFromPathToFileWithSettings

    }
}
//ExEnd:HTMLDcumentsComparisionClass