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
            string sourceDocumentPath = Constants.SourceWord;
            string targetDocumentPath = Constants.TargetWord;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(sourceDocumentPath))
            {
                comparer.Add(targetDocumentPath);
                comparer.Compare(outputFileName);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputFileName}.");
        }
    }
}