using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;
    /// <summary>
    /// This example demonstrates comparing of two documents with passwords
    /// </summary>
    class CompareDocumentsProtectedPath
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareDocumentsProtectedPath : comparing of two documents with passwords\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD_PROTECTED, new LoadOptions(){ Password = "1234" }))
            {
                comparer.Add(Constants.TARGET_WORD_PROTECTED, new LoadOptions() { Password = "5678" });
                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}