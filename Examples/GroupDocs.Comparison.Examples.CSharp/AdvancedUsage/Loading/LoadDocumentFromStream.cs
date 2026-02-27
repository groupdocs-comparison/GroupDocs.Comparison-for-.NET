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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # LoadDocumentFromStream : comparing of two documents loaded by file stream\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Stream sourceStream = File.OpenRead(Constants.SourceWord))
            using (Stream targetStream = File.OpenRead(Constants.TargetWord))
            {
                using (Comparer comparer = new Comparer(sourceStream))
                {
                    comparer.Add(targetStream);
                    comparer.Compare(File.Create(outputFileName));
                }
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
