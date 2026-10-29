using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents
    /// </summary>
    class PdfComparisonSample
    {
        public static void DisplayMode_SideBySide()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # PdfComparisonSample : comparing of two documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, "result_SideBySide.pdf");

            using (Comparer comparer = new Comparer(Constants.SourcePdfNew))
            {
                comparer.Add(Constants.TargetPdfNew);

                var options = new PdfCompareOptions()
                {
                    DisplayMode = PdfCompareOptions.ComparisonDisplayMode.SideBySide,
                };

                comparer.Compare(outputFileName, options);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        public static void DisplayMode_Inline()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # PdfComparisonSample : comparing of two documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, "result_Inline.pdf");

            using (Comparer comparer = new Comparer(Constants.SourcePdfNew))
            {
                comparer.Add(Constants.TargetPdfNew);

                var options = new PdfCompareOptions()
                {
                    DisplayMode = PdfCompareOptions.ComparisonDisplayMode.Inline,
                };

                comparer.Compare(outputFileName, options);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}