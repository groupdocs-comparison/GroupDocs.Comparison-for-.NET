using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates comparing of multi documents from path
    /// </summary>
    class CompareMultipleDocumentsSettingsPath
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsSettingsPath : comparing of multi documents from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Add(Constants.TARGET2_WORD);
                comparer.Add(Constants.TARGET3_WORD);
                CompareOptions compareOptions = new CompareOptions()
                {
                    InsertedItemStyle = new StyleSettings()
                    {
                        FontColor = System.Drawing.Color.Yellow
                    }
                };
                comparer.Compare(File.Create(outputFileName), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
