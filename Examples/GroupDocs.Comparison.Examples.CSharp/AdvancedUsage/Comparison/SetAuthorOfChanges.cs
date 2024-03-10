using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;
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

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                CompareOptions options = new CompareOptions()
                {
                    ShowRevisions = true,
                    WordTrackChanges = true,
                    RevisionAuthorName = "New author",
                };

                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare(Path.Combine(outputDirectory, Constants.RESULT_WITH_NEW_AUTHOR_WORD), options);
            }
            Console.WriteLine($"\nChanges updated successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
