using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates comparing of two images without SummaryPage
    /// </summary>
    public class CompareImageFromStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareImageFromStream : comparing of two images without SummaryPage\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultImage);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SourceImage)))
            {
                //If you set the GenerateSummaryPage property to true then the result will be saved in PDF format
                CompareOptions options = new CompareOptions()
                {
                    GenerateSummaryPage = false
                };

                comparer.Add(File.OpenRead(Constants.TargetImage));
                comparer.Compare(outputFileName, options);
            }
            Console.WriteLine($"\nImages compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}