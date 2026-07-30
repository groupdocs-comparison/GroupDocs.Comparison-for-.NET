using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    internal class CompareFolders
    {
        /// <summary>
        /// This example demonstrates how to compare folders and save result to TXT file
        /// </summary>
        public static void CompareFolderSaveAsTxt()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareFolders-CompareFolderSaveAsTxt : How to compare folders and save result to TXT file\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultFolder);

            Options.CompareOptions compareOptions = new Options.CompareOptions
            {
                DirectoryCompare = true,
                FolderComparisonExtension = FolderComparisonExtension.TXT
            };
            Comparer comparer = new Comparer(Constants.SourceFolder, compareOptions);
            comparer.Add(Constants.TargetFolder, compareOptions);
            comparer.Compare(outputFileName, compareOptions);

            Console.WriteLine($"\nFolders compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to compare folders and save result to HTML file
        /// </summary>
        public static void CompareFolderSaveAsHtml()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareFolders-CompareFolderSaveAsHtml : How to compare folders and save result to HTML file\n");


            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultFolder);

            Options.CompareOptions compareOptions = new Options.CompareOptions
            {
                DirectoryCompare = true,
                FolderComparisonExtension = FolderComparisonExtension.HTML
            };
            Comparer comparer = new Comparer(Constants.SourceFolder, compareOptions);
            comparer.Add(Constants.TargetFolder, compareOptions);
            comparer.Compare(outputFileName, compareOptions);

            Console.WriteLine($"\nFolders compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
