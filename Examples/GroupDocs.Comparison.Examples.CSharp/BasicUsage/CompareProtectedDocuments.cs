using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;
    /// <summary>
    /// This example demonstrates comparing of two documents with passwords
    /// </summary>
    class CompareProtectedDocuments
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareDocumentsProtectedPath : comparing of two documents with passwords\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(Constants.SourceWordProtected, 
                new LoadOptions(){ Password = "1234" }))
            {
                comparer.Add(Constants.TargetWordProtected, 
                    new LoadOptions() { Password = "5678" });

                var options = new WordCompareOptions()
                {
                    DisplayMode = WordCompareOptions.ComparisonDisplayMode.Revisions,
                    DetectStyleChanges = true
                };

                comparer.Compare(outputFileName, options);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}