//ExStart:PresentationDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Slides;
using GroupDocs.Comparison.Slides.Contracts;
using GroupDocs.Comparison.Slides.Contracts.Comparison;
using GroupDocs.Comparison.Slides.Contracts.Enums;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class PresentationDcumentsComparision
    {
        //ExStart:ComparePresentationFromStreamToFile
        /// <summary>
        /// Compare two Presentation from streams with saving results into a file
        /// </summary>
        public static void ComparePresentationFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:ComparePresentationFromStreamToFile

        //ExStart:ComparePresentationFromPathToFile
        /// <summary>
        /// Compare two Presentation from file path with saving results into a file
        /// </summary>
        public static void ComparePresentationFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides);
        }
        //ExEnd:ComparePresentationFromPathToFile

        //ExStart:ComparePresentationFromStreamToFileWithSettings
        /// <summary>
        /// Compare two Presentation from streams with saving results into a file with documen settings
        /// </summary>
        public static void ComparePresentationFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides, new SlidesComparisonSettings());

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:ComparePresentationFromStreamToFileWithSettings

        //ExStart:ComparePresentationFromPathToFileWithSettings
        /// <summary>
        /// Compare two Presentation from file path with saving results into a file with document settings
        /// </summary>
        public static void ComparePresentationFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides, new SlidesComparisonSettings());
        }
        //ExEnd:ComparePresentationFromPathToFileWithSettings
    }
}
//ExEnd:PresentationDcumentsComparisionClass