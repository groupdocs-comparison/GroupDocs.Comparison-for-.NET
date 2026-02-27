using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    /// <summary>
    /// This example demonstrates comparing of multi documents
    /// </summary>
    class CompareMultipleDocumentsStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsStream : comparing of multi documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SourceWord)))
            {
                comparer.Add(File.OpenRead(Constants.TargetWord));
                comparer.Add(File.OpenRead(Constants.Target2Word));
                comparer.Add(File.OpenRead(Constants.Target3Word));
                comparer.Compare(File.Create(outputFileName));
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
