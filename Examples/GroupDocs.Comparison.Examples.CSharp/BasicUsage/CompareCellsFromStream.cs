using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates comparing of two cells files
    /// </summary>
    class CompareCellsFromStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareCellsFromStream : comparing of two cells files\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_CELLS);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_CELLS)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_CELLS));
                comparer.Compare(File.Create(outputFileName));
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
