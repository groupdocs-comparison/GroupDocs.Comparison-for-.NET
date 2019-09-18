using GroupDocs.Comparison.Result;
using System;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to get changes from path
    /// </summary>
    class GetListOfChangesPath
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
            }
            Console.WriteLine($"\nChanges received successfully.");
        }
    }
}
