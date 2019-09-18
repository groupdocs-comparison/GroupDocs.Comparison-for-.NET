using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates comparing of multi protected documents from stream
    /// </summary>
    class CompareMultipleDocumentsProtectedStream
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD), new LoadOptions() { Password = "1234" }))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Add(File.OpenRead(Constants.TARGET2_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Add(File.OpenRead(Constants.TARGET3_WORD_PROTECTED), new LoadOptions() { Password = "5678" });
                comparer.Compare(File.Create(Constants.RESULT_WORD));
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}

