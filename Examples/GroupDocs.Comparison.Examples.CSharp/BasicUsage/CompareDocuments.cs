using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents
    /// </summary>
    class CompareDocuments
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareDocuments : comparing of two documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultCells);

            using (Comparer comparer = new Comparer(Constants.SourceCells))
            {
                comparer.Add(Constants.TargetCells);
                comparer.Compare(outputFileName);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}