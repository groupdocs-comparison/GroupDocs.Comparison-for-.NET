using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates comparing of multi documents
    /// </summary>
    class CompareMultipleDocumentsStream
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                comparer.Add(File.OpenRead(Constants.TARGET2_WORD));
                comparer.Add(File.OpenRead(Constants.TARGET3_WORD));
                comparer.Compare(File.Create(outputFileName));
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
