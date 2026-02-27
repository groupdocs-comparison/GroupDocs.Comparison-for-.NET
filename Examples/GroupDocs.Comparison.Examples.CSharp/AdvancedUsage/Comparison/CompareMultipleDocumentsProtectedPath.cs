using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates comparing of multi protected documents from path
    /// </summary>
    class CompareMultipleDocumentsProtectedPath
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsProtectedPath : Comparing multiple protected documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(Constants.SourceWord, new LoadOptions() { Password = "1234" }))
            {
                comparer.Add(Constants.TargetWordProtected, new LoadOptions() { Password = "5678" });
                comparer.Add(Constants.Target2WordProtected, new LoadOptions() { Password = "5678" });
                comparer.Add(Constants.Target3WordProtected, new LoadOptions() { Password = "5678" });
                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}

