using System;
using System.IO;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This class demonstrates comparing of multi documents
    /// </summary>
    class CompareMultipleDocumentsPath
    {
        /// <summary>
        /// This example demonstrates comparing of multi words documents
        /// </summary>
        public static void CompareMultipleWordsDocuments()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Add(Constants.TARGET2_WORD);
                comparer.Add(Constants.TARGET3_WORD);

                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi txt documents
        /// </summary>
        public static void CompareMultipleTxtDocuments()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_TXT);

            using (Comparer comparer = new Comparer(Constants.SOURCE_TXT))
            {
                comparer.Add(Constants.TARGET_TXT);
                comparer.Add(Constants.TARGET2_TXT);
                comparer.Add(Constants.TARGET3_TXT);
                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi email documents
        /// </summary>
        public static void CompareMultipleEmailDocuments()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_EMAIL);
            
            using (Comparer comparer = new Comparer(Constants.SOURCE_EMAIL))
            {
                comparer.Add(Constants.TARGET_EMAIL);
                comparer.Add(Constants.TARGET2_EMAIL);
                comparer.Add(Constants.TARGET3_EMAIL);
                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

    }
}
