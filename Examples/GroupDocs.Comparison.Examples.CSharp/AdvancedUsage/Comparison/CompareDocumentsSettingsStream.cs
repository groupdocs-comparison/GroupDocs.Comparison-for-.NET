using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates using some of compare settings
    /// </summary>
    class CompareDocumentsSettingsStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareDocumentsSettingsStream : Using some of compare settings\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                CompareOptions compareOptions = new CompareOptions()
                {
                    InsertedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Red,
                        FontColor = System.Drawing.Color.Green,
                        IsUnderline = true
                    }
                };
                comparer.Compare(File.Create(outputFileName), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
