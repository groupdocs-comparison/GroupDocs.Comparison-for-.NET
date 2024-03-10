using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Result;
    using GroupDocs.Comparison.Options;
    
    class GetChanges
    {
        /// <summary>
        /// This example demonstrates how to get changes coordinates
        /// </summary>
        public static void GetChangesCoordinates()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetChangesCoordinates : how to get changes coordinates\n");


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
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to get changes from path
        /// </summary>
        public static void GetListOfChangesPath()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetListOfChangesPath : how to get changes from path\n");

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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetListOfChangesStream : how to get changes from stream\n");

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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetSourceAndTargetTexts : how to get source and target texts\n");
            
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
