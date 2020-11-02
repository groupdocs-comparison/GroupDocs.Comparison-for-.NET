using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates using some of compare settings
    /// </summary>
    class CompareDocumentsGetExtendedSummaryPage
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD_EXTENDED_SUMMARYPAGE);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));

                //To get extended information about comparison, the GenerateSummaryPage property must be set to true
                CompareOptions compareOptions = new CompareOptions()
                {
	                GenerateSummaryPage = true,
                    ExtendedSummaryPage = true
                };
                comparer.Compare(File.Create(outputFileName), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
