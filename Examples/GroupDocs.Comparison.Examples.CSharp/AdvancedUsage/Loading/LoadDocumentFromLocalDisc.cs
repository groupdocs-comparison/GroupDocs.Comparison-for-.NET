using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates comparing of two documents loaded by file path
    /// </summary>
    class LoadDocumentFromLocalDisc
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # LoadDocumentFromLocalDisc : comparing of two documents loaded by file path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            string sourcePath = Constants.SourceWord;
            using (Comparer comparer = new Comparer(sourcePath))
            {
                string targetPath = Constants.SourceWord;
                comparer.Add(Constants.TargetWord);
                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
