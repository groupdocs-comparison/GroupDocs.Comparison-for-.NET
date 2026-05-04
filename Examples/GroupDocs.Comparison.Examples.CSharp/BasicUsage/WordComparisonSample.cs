using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents
    /// </summary>
    class WordComparisonSample
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # WordComparisonSample : comparing of two documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(Constants.SourceWord))
            {
                comparer.Add(Constants.TargetWord);
                var options = new WordCompareOptions()
                {
                    DisplayMode = WordCompareOptions.ComparisonDisplayMode.Revisions,
                    RevisionAuthorName = "GroupDocs",
                    CompareBookmarks = true
                };

                comparer.Compare(outputFileName, options);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}