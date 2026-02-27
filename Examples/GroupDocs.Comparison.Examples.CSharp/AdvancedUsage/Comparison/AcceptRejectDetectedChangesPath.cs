using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Result;
    using GroupDocs.Comparison.Options;
    
    /// <summary>
    /// This example demonstrates how to update changes from path
    /// </summary>
    class AcceptRejectDetectedChangesPath
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AcceptRejectDetectedChangesPath : How to update changes from path\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileNameWithAcceptedChange = Path.Combine(outputDirectory, Constants.ResultWithAcceptedChangeWord);
            string outputFileNameWithRejectedChange = Path.Combine(outputDirectory, Constants.ResultWithRejectedChangeWord);

            using (Comparer comparer = new Comparer(Constants.SourceWord))
            {
                comparer.Add(Constants.TargetWord);
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
