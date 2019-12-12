using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates comparing of two documents loaded by file stream
    /// </summary>
    class LoadDocumentFromStream
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Stream sourceStream = File.OpenRead(Constants.SOURCE_WORD))
            using (Stream targetStream = File.OpenRead(Constants.TARGET_WORD))
            {
                using (Comparer comparer = new Comparer(sourceStream))
                {
                    comparer.Add(targetStream);
                    comparer.Compare(File.Create(outputFileName));
                }
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
