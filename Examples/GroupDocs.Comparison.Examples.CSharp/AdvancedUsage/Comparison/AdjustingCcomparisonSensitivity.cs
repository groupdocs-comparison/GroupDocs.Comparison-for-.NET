using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two documents using sensitivity option
    /// </summary>
    class AdjustingCcomparisonSensitivity
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare(File.Create(Constants.RESULT_WORD), new CompareOptions() { SensitivityOfComparison = 100 });
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
