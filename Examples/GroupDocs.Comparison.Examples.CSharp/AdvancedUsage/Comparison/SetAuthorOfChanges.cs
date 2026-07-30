using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;
    using static GroupDocs.Comparison.Options.WordCompareOptions;

    /// <summary>
    /// This example demonstrates how to set author of changes
    /// </summary>
    class SetAuthorOfChanges
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SetAuthorOfChanges : how to set author of changes\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();

            using (Comparer comparer = new Comparer(Constants.SourceWord))
            {
                var options = new WordCompareOptions()
                {
                    ShowRevisions = true,
                    DisplayMode = ComparisonDisplayMode.Revisions,
                    RevisionAuthorName = "New author",
                };

                comparer.Add(Constants.TargetWord);
                comparer.Compare(Path.Combine(outputDirectory, Constants.ResultWithNewAuthorWord), options);
            }
            Console.WriteLine($"\nChanges updated successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
