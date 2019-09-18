using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to update changes from stream
    /// </summary>
    class AcceptRejectDetectedChangesStream
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
                // inserted word "Cool" was not be added to result document
                changes[0].ComparisonAction = ComparisonAction.Reject;
                comparer.ApplyChanges(File.Create(Constants.RESULT_WORD), new ApplyChangeOptions() { Changes = changes });
            }
            Console.WriteLine($"\nChanges updated successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
