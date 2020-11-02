using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to update changes from path
    /// </summary>
    class AcceptRejectDetectedChangesPath
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileNameWithAcceptedChange = Path.Combine(outputDirectory, Constants.RESULT_WITH_ACCEPTED_CHANGE_WORD);
            string outputFileNameWithRejectedChange = Path.Combine(outputDirectory, Constants.RESULT_WITH_REJECTED_CHANGE_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
                // inserted word "Cool" was not be added to result document
                changes[0].ComparisonAction = ComparisonAction.Reject;
                comparer.ApplyChanges(outputFileNameWithRejectedChange, new ApplyChangeOptions { Changes = changes, SaveOriginalState = true });
                changes = comparer.GetChanges();
                changes[0].ComparisonAction = ComparisonAction.Accept;
                comparer.ApplyChanges(outputFileNameWithAcceptedChange, new ApplyChangeOptions { Changes = changes });
            }
            Console.WriteLine($"\nChanges updated successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
