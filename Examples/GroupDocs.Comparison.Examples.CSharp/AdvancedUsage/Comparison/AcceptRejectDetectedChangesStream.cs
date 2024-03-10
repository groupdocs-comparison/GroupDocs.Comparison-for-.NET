using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Result;
    using GroupDocs.Comparison.Options;
    
    /// <summary>
    /// This example demonstrates how to update changes from stream
    /// </summary>
    class AcceptRejectDetectedChangesStream
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AcceptRejectDetectedChangesStream : How to update changes from stream\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileNameWithAcceptedChange = Path.Combine(outputDirectory, Constants.RESULT_WITH_ACCEPTED_CHANGE_WORD);
            string outputFileNameWithRejectedChange = Path.Combine(outputDirectory, Constants.RESULT_WITH_REJECTED_CHANGE_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
                // inserted word "Cool" was not be added to result document
                changes[0].ComparisonAction = ComparisonAction.Reject;
                comparer.ApplyChanges(outputFileNameWithRejectedChange, new ApplyChangeOptions { Changes = changes, SaveOriginalState = true });
                changes = comparer.GetChanges();
                changes[0].ComparisonAction = ComparisonAction.Accept;
                comparer.ApplyChanges(outputFileNameWithAcceptedChange, new ApplyChangeOptions { Changes = changes });
            }
            Console.WriteLine($"\nChanges updated successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
