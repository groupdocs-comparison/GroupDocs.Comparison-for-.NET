//ExStart:CommonComparisionOperationsClass
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
    class CommonComparisionOperations
    {
        #region Common operations with automatic file format detection

        //ExStart:CompareWithAutomaticFormatDetectionFromPath
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a stream
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPath()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile));
        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPath

        //ExStart:CompareWithAutomaticFormatDetectionFromPathToFile
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a file
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPathToFile

        //ExStart:CompareWithAutomaticFormatDetectionFromPathToFileWithExtension
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a file with extension
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPathToFileWithExtension()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), FileType.Docx);
        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPathToFileWithExtension

        //ExStart:CompareWithAutomaticFormatDetectionFromPathWithSettings
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a stream with comparison settings
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPathWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), new WordsComparisonSettings());
        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPathWithSettings

        //ExStart:CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a stream with comparison type and settings
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), ComparisonType.Words, new WordsComparisonSettings());
        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType

        //ExStart:CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType
        /// <summary>
        /// Compare two documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
        /// </summary>
        public static void CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, new WordsComparisonSettings(), FileType.Docx);

            // Get all changes
            GroupDocs.Comparison.Common.Changes.ChangeInfo[] changes = comparison.GetChanges();
            if (changes != null)
            {
                foreach (GroupDocs.Comparison.Common.Changes.ChangeInfo change in changes)
                {
                    Console.WriteLine("Page ID: " + change.Page.Id.ToString() + " Page Height:" + change.Page.Height.ToString() + " Width:" + change.Page.Width.ToString());
                    Console.WriteLine("Change Type: " + change.Type.ToString());
                    Console.WriteLine("Change Text: " + change.Text);
                    // to get style changes
                    //change.StyleChanges
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
        //ExEnd:CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType

        #endregion

        #region Common comparison operations with encrypted files

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPath
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a stream
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPath()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Common.targetFilePassword);
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPath

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a file
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile));
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a file with extension
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile), FileType.Docx);
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison settings
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, new WordsComparisonSettings());
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison type and settings
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, ComparisonType.Words, new WordsComparisonSettings());
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType

        //ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType
        /// <summary>
        /// Compare two encrypted documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
        /// </summary>
        public static void CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType()
        {
            // Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, new WordsComparisonSettings(), FileType.Docx);

            // Get all changes
            GroupDocs.Comparison.Common.Changes.ChangeInfo[] changes = comparison.GetChanges();
            if (changes != null)
            {
                foreach (GroupDocs.Comparison.Common.Changes.ChangeInfo change in changes)
                {
                    Console.WriteLine("Page ID: " + change.Page.Id.ToString() + " Page Height:" + change.Page.Height.ToString() + " Width:" + change.Page.Width.ToString());
                    Console.WriteLine("Change Type: " + change.Type.ToString());
                    Console.WriteLine("Change Text: " + change.Text);
                    // to get style changes
                    //change.StyleChanges
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        //ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType


        #endregion
    }
}
//ExEnd:CommonComparisionOperationsClass