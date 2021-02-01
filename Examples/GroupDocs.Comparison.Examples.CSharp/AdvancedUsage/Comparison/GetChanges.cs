using System;
using System.IO;
using GroupDocs.Comparison.Options;
using GroupDocs.Comparison.Result;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison
{
    class GetChanges
    {
        /// <summary>
        /// This example demonstrates how to get changes coordinates
        /// </summary>
        public static void GetChangesCoordinates()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                CompareOptions compareOptions = new CompareOptions() { CalculateCoordinates = true };
                comparer.Compare(File.Create(outputFileName), compareOptions);
                ChangeInfo[] changes = comparer.GetChanges();
                foreach (var change in changes)
                    Console.WriteLine("Change Type: {0}, X: {1}, Y: {2}, Text: {3}", change.Type, change.Box.X, change.Box.Y, change.Text);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to get changes from path
        /// </summary>
        public static void GetListOfChangesPath()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
            }
            Console.WriteLine($"\nChanges received successfully.");
        }

        /// <summary>
        /// This example demonstrates how to get changes from stream
        /// </summary>
        public static void GetListOfChangesStream()
        {
            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                comparer.Compare();
                ChangeInfo[] changes = comparer.GetChanges();
            }
            Console.WriteLine($"\nChanges received successfully.");
        }

        /// <summary>
        /// This example demonstrates how to get source and target texts 
        /// </summary>
        public static void GetSourceAndTargetTexts()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Compare();

                ChangeInfo[] changes = comparer.GetChanges();
                foreach (ChangeInfo change in changes)
                {
	                Console.WriteLine("");
                    Console.WriteLine("Source text: " + change.SourceText);
	                Console.WriteLine("Target text: " + change.TargetText);
	            }
            }
            Console.WriteLine($"\nGet Source and Target Texts received successfully.");
        }

    }
}
