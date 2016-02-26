//ExStart:TextDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Text;
using GroupDocs.Comparison.Text.Contracts;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class TextDcumentsComparision
    {
        //ExStart:CompareTextDcumentsFromStreamToFile
        /// <summary>
        /// Compare two Text processing documents from streams with saving results into a file
        /// </summary>
        public static void CompareTextDcumentsFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareTextDcumentsFromStreamToFile

        //ExStart:CompareTextDcumentsFromPathToFile
        /// <summary>
        /// Compare two Text processing documents from file path with saving results into a file
        /// </summary>
        public static void CompareTextDcumentsFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text);
        }
        //ExEnd:CompareTextDcumentsFromPathToFile

        //ExStart:CompareTextDcumentsFromStreamToFileWithSettings
        /// <summary>
        /// Compare two Text processing documents from streams with saving results into a file with documen settings
        /// </summary>
        public static void CompareTextDcumentsFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text, new TextComparisonSettings());

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareTextDcumentsFromStreamToFileWithSettings

        //ExStart:CompareTextDcumentsFromPathToFileWithSettings
        /// <summary>
        /// Compare two Text processing documents from file path with saving results into a file with document settings
        /// </summary>
        public static void CompareTextDcumentsFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text, new TextComparisonSettings());
        }
        //ExEnd:CompareTextDcumentsFromPathToFileWithSettings
    
    }
}
//ExEnd:TextDcumentsComparisionClass