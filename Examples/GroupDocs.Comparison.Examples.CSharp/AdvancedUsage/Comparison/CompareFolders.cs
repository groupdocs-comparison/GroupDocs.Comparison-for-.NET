using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    internal class CompareFolders
    {
        /// <summary>
        /// This example demonstrates how to compare folders and save result to TXT file
        /// </summary>
        public static void CompareFolderSaveAsTxt()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_FOLDER);

            Options.CompareOptions compareOptions = new Options.CompareOptions
            {
                DirectoryCompare = true,
                FolderComparisonExtension = FolderComparisonExtension.TXT
            };
            Comparer comparer = new Comparer(Constants.SOURCE_FOLDER, compareOptions);
            comparer.Add(Constants.TARGET_FOLDER, compareOptions);
            comparer.Compare(outputFileName, compareOptions);

            Console.WriteLine($"\nFolders compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to compare folders and save result to HTML file
        /// </summary>
        public static void CompareFolderSaveAsHtml()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_FOLDER);

            Options.CompareOptions compareOptions = new Options.CompareOptions
            {
                DirectoryCompare = true,
                FolderComparisonExtension = FolderComparisonExtension.HTML
            };
            Comparer comparer = new Comparer(Constants.SOURCE_FOLDER, compareOptions);
            comparer.Add(Constants.TARGET_FOLDER, compareOptions);
            comparer.Compare(outputFileName, compareOptions);

            Console.WriteLine($"\nFolders compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
