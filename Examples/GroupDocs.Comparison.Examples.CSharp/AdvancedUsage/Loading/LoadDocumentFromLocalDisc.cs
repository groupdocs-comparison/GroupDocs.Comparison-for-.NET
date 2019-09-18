using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates comparing of two documents loaded by file path
    /// </summary>
    class LoadDocumentFromLocalDisc
    {
        public static void Run()
        {
            string sourcePath = Constants.SOURCE_WORD;
            using (Comparer comparer = new Comparer(sourcePath))
            {
                string targetPath = Constants.SOURCE_WORD;
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare(Constants.RESULT_WORD);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
