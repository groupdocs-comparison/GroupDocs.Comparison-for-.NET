using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates OCR comparing of two images
    /// </summary>
    public class OcrComparison
    {
        public static void DisplayMode_SideBySide()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # OcrComparison : OCR comparing of two images\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, "result_SideBySide.png");

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.OcrSourceImage)))
            {
                var options = new CompareOptions
                {
                    Ocr = new OcrOptions 
                    { 
                        Enabled = true,
                        DisplayMode = OcrDisplayMode.SideBySide
                    },
                    GenerateSummaryPage = false
                };

                comparer.Add(File.OpenRead(Constants.OcrTargetImage));
                comparer.Compare(outputFileName, options);
            }
            Console.WriteLine($"\nOCR comparing of two images finished successfully.\nCheck output in {outputDirectory}.");
        }

        public static void DisplayMode_Text()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # OcrComparison : OCR comparing of two images\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, "result_Text.png");

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.OcrSourceImage)))
            {
                var options = new CompareOptions
                {
                    Ocr = new OcrOptions
                    {
                        Enabled = true,
                        DisplayMode = OcrDisplayMode.Text
                    },
                    GenerateSummaryPage = false
                };

                comparer.Add(File.OpenRead(Constants.OcrTargetImage));
                comparer.Compare(outputFileName, options);
            }
            Console.WriteLine($"\nOCR comparing of two images finished successfully.\nCheck output in {outputDirectory}.");
        }
    }
}