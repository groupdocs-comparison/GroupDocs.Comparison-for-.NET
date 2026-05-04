using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents
    /// </summary>
    class PdfComparisonSample
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # PdfComparisonSample : comparing of two documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultPdf);

            using (Comparer comparer = new Comparer(Constants.SourcePdf))
            {
                comparer.Add(Constants.TargetPdf);
                comparer.Compare(outputFileName);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}