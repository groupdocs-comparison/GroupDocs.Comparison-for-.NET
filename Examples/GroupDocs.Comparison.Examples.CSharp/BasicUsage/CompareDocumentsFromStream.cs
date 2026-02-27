using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents
    /// </summary>
    class CompareDocumentsFromStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareDocumentsFromStream : comparing of two documents from stream\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultPdf);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SourcePdf)))
            {
                comparer.Add(File.OpenRead(Constants.TargetPdf));
                var options = new CompareOptions()
                {
                    GenerateSummaryPage = true
                };

                comparer.Compare(File.Create(outputFileName), options);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}