using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;
    /// <summary>
    /// This example demonstrates comparing of multi documents from stream
    /// </summary>
    class CompareMultipleDocumentsSettingsStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsSettingsStream : comparing of multi documents from stream\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                comparer.Add(File.OpenRead(Constants.TARGET2_WORD));
                comparer.Add(File.OpenRead(Constants.TARGET3_WORD));
                CompareOptions compareOptions = new CompareOptions()
                {
                    InsertedItemStyle = new StyleSettings()
                    {
                        FontColor = System.Drawing.Color.Yellow
                    }
                };
                comparer.Compare(File.Create(outputFileName), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
