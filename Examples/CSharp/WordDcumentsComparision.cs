//ExStart:WordDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Words.Contracts;
using GroupDocs.Comparison.Words.Contracts.Enums;
using GroupDocs.Comparison.Words.Contracts.Nodes;
using GroupDocs.Comparison.Words.Nodes;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class WordDcumentsComparision
    {
        //ExStart:CompareWordDcumentsFromStreamToFile
        /// <summary>
        /// Compare two word processing documents from streams with saving results into a file
        /// </summary>
        public static void CompareWordDcumentsFromStreamToFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareWordDcumentsFromStreamToFile

        //ExStart:CompareWordDcumentsFromPathToFile
        /// <summary>
        /// Compare two word processing documents from file path with saving results into a file
        /// </summary>
        public static void CompareWordDcumentsFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words);
        }
        //ExEnd:CompareWordDcumentsFromPathToFile

        //ExStart:CompareWordDcumentsFromStreamToFileWithSettings
        /// <summary>
        /// Compare two word processing documents from streams with saving results into a file with documen settings
        /// </summary>
        public static void CompareWordDcumentsFromStreamToFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            WordsComparisonSettings objWordsComparisonSettings = new WordsComparisonSettings();
            objWordsComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;


            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), objWordsComparisonSettings);

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareWordDcumentsFromStreamToFileWithSettings

        //ExStart:CompareWordDcumentsFromPathToFileWithSettings
        /// <summary>
        /// Compare two word processing documents from file path with saving results into a file with document settings
        /// </summary>
        public static void CompareWordDcumentsFromPathToFileWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words,new WordsComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, IsMultipleComparison = true, GenerateSummaryPage = true, });
        }
        //ExEnd:CompareWordDcumentsFromPathToFileWithSettings

        //ExStart:CompareMultipleTargetWordDcumentsFromPathToFileWithSettings
        /// <summary>
        /// Compare Two target  word processing documents using method MultiCompareWith from file path with saving results into a file with document settings
        /// </summary>
        public static void ComparetwoTargetWordDcumentsFromPathToFileWithSettings()
        {
            // Create list of targets documents
            List<IComparisonDocument> ListOfTargetDocuments = new List<IComparisonDocument>();

            // Open documents 
            ComparisonDocument source = new ComparisonDocument(Path.Combine(Common.sourcePath, Common.sourceFile));
            ComparisonDocument target1 = new ComparisonDocument(Path.Combine(Common.targetPath, "target.docx"));
            ComparisonDocument target2 = new ComparisonDocument(Path.Combine(Common.targetPath, "target2.docx"));

            // Add target documents in list
            ListOfTargetDocuments.Add(target1);
            ListOfTargetDocuments.Add(target2);

            // Call method MultiCompareWith
            IWordsCompareResult result = source.MultiCompareWith(ListOfTargetDocuments, new WordsComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, IsMultipleComparison = true, GenerateSummaryPage = true });

            // Call GetDocument() method
            IComparisonDocument resultDocument = result.GetDocument();

            // Call Save() method
            resultDocument.Save(Path.Combine(Common.resultPath, Common.resultFile), ComparisonSaveFormat.Docx);

        }
        //ExEnd:ComparetwoTargetWordDcumentsFromPathToFileWithSettings


        // Compare multiple target  word processing documents using method MultiCompareWith from file path with saving results into a file with document settings
        /// </summary>
        public static void CompareMultipleTargetWordDcumentsFromPathToFileWithSettings()
        {
            // Create list of targets documents
            List<IComparisonDocument> ListOfTargetDocuments = new List<IComparisonDocument>();

            // Open documents 
            ComparisonDocument source = new ComparisonDocument(Path.Combine(Common.sourcePath, Common.sourceFile));
            ComparisonDocument target1 = new ComparisonDocument(Path.Combine(Common.targetPath, "target.docx"));
            ComparisonDocument target2 = new ComparisonDocument(Path.Combine(Common.targetPath, "target2.docx"));
            ComparisonDocument target3 = new ComparisonDocument(Path.Combine(Common.targetPath, "target3.docx"));

            // Add target documents in list
            ListOfTargetDocuments.Add(target1);
            ListOfTargetDocuments.Add(target2);
            ListOfTargetDocuments.Add(target3);

            // Call method MultiCompareWith
            IWordsCompareResult result = source.MultiCompareWith(ListOfTargetDocuments, new WordsComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, IsMultipleComparison = true, GenerateSummaryPage = true });

            // Call GetDocument() method
            IComparisonDocument resultDocument = result.GetDocument();

            // Call Save() method
            resultDocument.Save(Path.Combine(Common.resultPath, Common.resultFile), ComparisonSaveFormat.Docx);

        }
        //ExEnd:CompareMultipleTargetWordDcumentsFromPathToFileWithSettings
    }
}
//ExEnd:WordDcumentsComparisionClass