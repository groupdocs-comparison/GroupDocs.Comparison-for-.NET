//ExStart:CommonComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Common.Changes;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class CommonComparision
    {
        //ExStart:CompareDcumentsFromStreamToOutputStream
        /// <summary>
        /// Compare two documents from streams with saving results into a stream
        /// </summary>
        public static void CompareDcumentsFromStreamToOutputStream()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(sourceStream, targetStream, new ComparisonSettings());

            // get result document as stream.
            Stream stream = result.GetStream();

            sourceStream.Close();
            targetStream.Close();
            stream.Close();
        }
        //ExEnd:CompareDcumentsFromStreamToOutputStream

        //ExStart:CompareDcumentsFromStreamToOutputFile
        /// <summary>
        /// Compare two documents from streams with saving results into a file.
        /// </summary>
        public static void CompareDcumentsFromStreamToOutputFile()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(sourceStream, targetStream, new ComparisonSettings { DeletedItemsStyle = new StyleSettings { StrikeThrough = true }, GenerateSummaryPage = true, DetailLevel = DetailLevel.Hight });

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareDcumentsFromStreamToOutputFile

        //ExStart:CompareDcumentsFromPathToOutputStream
        /// <summary>
        /// Compare two documents from file path with saving results into a stream
        /// </summary>
        public static void CompareDcumentsFromPathToOutputStream()
        {
            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new ComparisonSettings { DeletedItemsStyle = new StyleSettings { StrikeThrough = true } });

            // get result document as stream.
            Stream stream = result.GetStream();

            stream.Close();
        }
        //ExEnd:CompareDcumentsFromPathToOutputStream

        //ExStart:CompareDcumentsFromPathToOutputFile
        /// <summary>
        /// Compare two documents from file path with saving results into a file
        /// </summary>
        public static void CompareDcumentsFromPathToOutputFile()
        {
            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new ComparisonSettings());

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareDcumentsFromPathToOutputFile

        //ExStart:CompareDcumentsFromStreamToOutputFileWithSettings
        /// <summary>
        /// Compare two documents from streams with saving results into a file with comparison settings
        /// </summary>
        public static void CompareDcumentsFromStreamToOutputFileWithSettings()
        {
            // Create two streams of documents
            Stream sourceStream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read);
            Stream targetStream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read);

            // define and set comparison settings and properties.
            ComparisonSettings objComparisonSettings = new ComparisonSettings();
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;


            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(sourceStream, targetStream, objComparisonSettings);

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));

            sourceStream.Close();
            targetStream.Close();
        }
        //ExEnd:CompareDcumentsFromStreamToOutputFileWithSettings

        //ExStart:CompareDcumentsFromFileToOutputFileWithSettings
        /// <summary>
        /// Compare two documents from file path with saving results into a file with comparison settings
        /// </summary>
        public static void CompareDcumentsFromFileToOutputFileWithSettings()
        {
            // define and set comparison settings and properties.
            ComparisonSettings objComparisonSettings = new ComparisonSettings();
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;


            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), objComparisonSettings);

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareDcumentsFromFileToOutputFileWithSettings


        //ExStart:CompareEncryptedFilesToOutputFileWithSettings
        /// <summary>
        /// Compare two encrypted/password protected documents from file path with saving results into a file with comparison settings
        /// </summary>
        public static void CompareEncryptedFilesToOutputFileWithSettings()
        {
            // define and set comparison settings and properties.
            ComparisonSettings objComparisonSettings = new ComparisonSettings();
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;


            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, objComparisonSettings);

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareEncryptedFilesToOutputFileWithSettings

        //ExStart:CompareMultipleDcumentsFromFileToOutputFileWithSettings
        /// <summary>
        /// Compare multiple (e.g 3) documents from file path with saving results into a file with comparison settings
        /// </summary>
        public static void CompareMultipleDcumentsFromFileToOutputFileWithSettings()
        {
            // define and set comparison settings and properties.
            ComparisonSettings objComparisonSettings = new ComparisonSettings();
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;

            // source file to compare.
            string source = Path.Combine(Common.sourcePath, Common.sourceFile);

            // target files to compare with.
            List<string> targets = new List<string>
            {
                Path.Combine(Common.targetPath, Common.targetFile),
                Path.Combine(Common.targetPath, "target1.docx"),
                Path.Combine(Common.targetPath, "target2.docx")
            };
            // Get instance of GroupDocs.Comparison.MultiComparer and call method Compare.
            GroupDocs.Comparison.MultiComparer comparison = new GroupDocs.Comparison.MultiComparer();

            ICompareResult result = comparison.Compare(source, targets, objComparisonSettings);

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareMultipleDcumentsFromFileToOutputFileWithSettings

        //ExStart:CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings
        /// <summary>
        /// Compare multiple (e.g 3) encrypted/password protected documents from file path with saving results into a file with comparison settings
        /// </summary>
        public static void CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings()
        {
            // define and set comparison settings and properties.
            ComparisonSettings objComparisonSettings = new ComparisonSettings();
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow;

            // source file to compare.
            string source = Path.Combine(Common.sourcePath, Common.sourceFile);

            // target files to compare with.
            List<string> targets = new List<string>
            {
                Path.Combine(Common.targetPath, Common.targetFile),
                Path.Combine(Common.targetPath, "target1.docx"),
                Path.Combine(Common.targetPath, "target2.docx")
            };

            // target files passwords to compare with.
            List<string> targetsPasswords = new List<string>
            {
                Path.Combine(Common.targetPath, Common.targetFilePassword),
                Path.Combine(Common.targetPath, "secret"),
                Path.Combine(Common.targetPath, "secret")
            };
            // Get instance of GroupDocs.Comparison.MultiComparer and call method Compare.
            GroupDocs.Comparison.MultiComparer comparison = new GroupDocs.Comparison.MultiComparer();

            ICompareResult result = comparison.Compare(source, Common.sourceFilePassword, targets, targetsPasswords, objComparisonSettings);

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings

        //ExStart:CompareDcumentsToGetChanges
        /// <summary>
        /// Compare two documents from file path with saving results into a file with document settings and allow to get changes, update changes
        /// </summary>
        public static void CompareDcumentsToGetChanges()
        {
            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new ComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, GenerateSummaryPage = true });

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));

            //Get array of changes
            ChangeInfo[] changes = result.GetChanges();

            //Set actions of changes as Accept or Reject
            changes[0].Action = ComparisonAction.Accept;
            changes[1].Action = ComparisonAction.Reject;

            //Update changes in CompareResult object (this method updated result document)
            result.UpdateChanges(changes);
        }
        //ExEnd:CompareDcumentsToGetChanges

        //ExStart:CompareDcumentsToGetDocumentImages
        /// <summary>
        /// Compare two documents from file path with saving results into a file with document settings and get result images.
        /// </summary>
        public static void CompareDcumentsToGetDocumentImages()
        {
            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new ComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, GenerateSummaryPage = true });

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));

            //Get images of result document as array of streams 
            Stream[] imgStreams = result.GetImages();
        }
        //ExEnd:CompareDcumentsToGetDocumentImages

        //ExStart:CompareDcumentsToGetDocumentImagesInFolder
        /// <summary>
        /// Compare two documents from file path with saving results into a file with document settings and get result images into a folder.
        /// </summary>
        public static void CompareDcumentsToGetDocumentImagesInFolder()
        {
            // Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            GroupDocs.Comparison.Comparer comparison = Common.getComparison();
            ICompareResult result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new ComparisonSettings { StyleChangeDetection = true, ShowDeletedContent = true, GenerateSummaryPage = true });

            // save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile));

            //Save images of result document to folder
            result.SaveImages(Common.resultPath);
        }
        //ExEnd:CompareDcumentsToGetDocumentImagesInFolder
    }
}
//ExEnd:CommonComparisionClass