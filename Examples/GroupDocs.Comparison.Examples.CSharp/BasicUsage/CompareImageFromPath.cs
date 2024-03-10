using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates comparing of two images without SummaryPage
    /// </summary>
    class CompareImageFromPath
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareImageFromPath : comparing of two images without SummaryPage\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_IMAGE);

            using (Comparer comparer = new Comparer(Constants.SOURCE_IMAGE))
            {
                //If you set the GenerateSummaryPage property to true then the result will be saved in PDF format
                CompareOptions options = new CompareOptions();
                options.GenerateSummaryPage = false;

                comparer.Add(Constants.TARGET_IMAGE);
                comparer.Compare(outputFileName, options);
            }
            Console.WriteLine($"\nImages compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}