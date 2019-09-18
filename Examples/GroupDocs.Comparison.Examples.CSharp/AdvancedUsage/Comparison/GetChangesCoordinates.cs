using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to get changes coordinates
    /// </summary>
    class GetChangesCoordinates
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                CompareOptions compareOptions = new CompareOptions(){ CalculateCoordinates = true };
                comparer.Compare(File.Create(Constants.RESULT_WORD), compareOptions);
                ChangeInfo[] changes = comparer.GetChanges();
                foreach (var change in changes)
                    Console.WriteLine("Change Type: {0}, X: {1}, Y: {2}, Text: {3}", change.Type, change.Box.X, change.Box.Y, change.Text);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
