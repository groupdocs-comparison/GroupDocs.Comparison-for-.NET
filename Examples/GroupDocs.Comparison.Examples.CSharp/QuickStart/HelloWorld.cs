using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.QuickStart
{
    /// <summary>
    /// This example demonstrates how to compare two documents.
    /// </summary>
    class HelloWorld
    {
        public static void Run()
        {
            string sourceDocumentPath = Constants.SOURCE_WORD;
            string targetDocumentPath = Constants.TARGET_WORD;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(sourceDocumentPath))
            {
                comparer.Add(targetDocumentPath);
                comparer.Compare(outputFileName);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputFileName}.");
        }
    }
}