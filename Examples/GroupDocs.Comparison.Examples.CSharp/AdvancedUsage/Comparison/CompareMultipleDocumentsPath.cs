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
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Add(Constants.TARGET2_WORD);
                comparer.Add(Constants.TARGET3_WORD);
                comparer.Compare(Constants.RESULT_WORD);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi txt documents
        /// </summary>
        public static void CompareMultipleTxtDocuments()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_TXT))
            {
                comparer.Add(Constants.TARGET_TXT);
                comparer.Add(Constants.TARGET2_TXT);
                comparer.Add(Constants.TARGET3_TXT);
                comparer.Compare(File.Create(Constants.RESULT_TXT), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi email documents
        /// </summary>
        public static void CompareMultipleEmailDocuments()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_EMAIL))
            {
                comparer.Add(Constants.TARGET_EMAIL);
                comparer.Add(Constants.TARGET2_EMAIL);
                comparer.Add(Constants.TARGET3_EMAIL);
                comparer.Compare(File.Create(Constants.RESULT_EMAIL), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

    }
}
