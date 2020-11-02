using System;
using System.IO;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two images without SummaryPage
    /// </summary>
    public class CompareImageFromStream
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_IMAGE);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_IMAGE)))
            {
	            //If you set the GenerateSummaryPage property to true then the result will be saved in PDF format
                CompareOptions options = new CompareOptions();
	            options.GenerateSummaryPage = false;

                comparer.Add(File.OpenRead(Constants.TARGET_IMAGE));
                comparer.Compare(outputFileName, options);
            }
            Console.WriteLine($"\nImages compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}