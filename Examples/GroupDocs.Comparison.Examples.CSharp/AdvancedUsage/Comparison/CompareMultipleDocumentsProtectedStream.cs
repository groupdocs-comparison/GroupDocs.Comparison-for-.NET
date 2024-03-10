using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates comparing of multi protected documents from stream
    /// </summary>
    class CompareMultipleDocumentsProtectedStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsProtectedStream : comparing of multi protected documents from stream\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD), new LoadOptions() { Password = "1234" }))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Add(File.OpenRead(Constants.TARGET2_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Add(File.OpenRead(Constants.TARGET3_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Compare(File.Create(outputFileName));
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}

