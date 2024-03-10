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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareMultipleDocumentsPath-CompareMultipleWordsDocuments : Comparing of multiple words documents\n");
            
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                comparer.Add(Constants.TARGET2_WORD);
                comparer.Add(Constants.TARGET3_WORD);

                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nWord Documents compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi txt documents
        /// </summary>
        public static void CompareMultipleTxtDocuments()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Basic Usage] # CompareMultipleDocumentsPath-CompareMultipleTxtDocuments : Comparing of multiple text documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_TXT);

            using (Comparer comparer = new Comparer(Constants.SOURCE_TXT))
            {
                comparer.Add(Constants.TARGET_TXT);
                comparer.Add(Constants.TARGET2_TXT);
                comparer.Add(Constants.TARGET3_TXT);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nText documents compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
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
            Console.WriteLine($"\nEmail documents compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi pdf documents
        /// </summary>
        public static void CompareMultiplePdfDocuments()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_PDF);

            using (Comparer comparer = new Comparer(Constants.SOURCE_PDF))
            {
                comparer.Add(Constants.TARGET_PDF);
                comparer.Add(Constants.TARGET2_PDF);
                comparer.Add(Constants.TARGET3_PDF);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nPDF documents compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi diagram documents
        /// </summary>
        public static void CompareMultipleDiagramDocuments()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_DIAGRAM);

            using (Comparer comparer = new Comparer(Constants.SOURCE_DIAGRAM))
            {
                comparer.Add(Constants.TARGET_DIAGRAM);
                comparer.Add(Constants.TARGET2_DIAGRAM);
                comparer.Add(Constants.TARGET3_DIAGRAM);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions() { DiagramMasterSetting = new DiagramMasterSetting() { MasterPath = Constants.DIAGRAM_SETTINGS } });
            }
            Console.WriteLine($"\nDiagram documents compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

    }
}
