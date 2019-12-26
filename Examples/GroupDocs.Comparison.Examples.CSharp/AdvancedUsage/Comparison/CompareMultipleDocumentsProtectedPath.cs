using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates comparing of multi protected documents from path
    /// </summary>
    class CompareMultipleDocumentsProtectedPath
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD, new LoadOptions() { Password = "1234" }))
            {
                comparer.Add(Constants.TARGET_WORD_PROTECTED, new LoadOptions() { Password = "5678" });
                comparer.Add(Constants.TARGET2_WORD_PROTECTED, new LoadOptions() { Password = "5678" });
                comparer.Add(Constants.TARGET3_WORD_PROTECTED, new LoadOptions() { Password = "5678" });
                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}

