using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

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
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsPath-CompareMultipleWordsDocuments : Comparing of multiple words documents\n");
            
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            using (Comparer comparer = new Comparer(Constants.SourceWord))
            {
                comparer.Add(Constants.TargetWord);
                comparer.Add(Constants.Target2Word);
                comparer.Add(Constants.Target3Word);

                comparer.Compare(outputFileName);
            }
            Console.WriteLine($"\nWord Documents compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi txt documents
        /// </summary>
        public static void CompareMultipleTxtDocuments()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsPath-CompareMultipleTxtDocuments : Comparing of multiple text documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultTxt);

            using (Comparer comparer = new Comparer(Constants.SourceTxt))
            {
                comparer.Add(Constants.TargetTxt);
                comparer.Add(Constants.Target2Txt);
                comparer.Add(Constants.Target3Txt);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nText documents compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi email documents
        /// </summary>
        public static void CompareMultipleEmailDocuments()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsPath-CompareMultipleEmailDocuments : Comparing of multiple email documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultEmail);
            
            using (Comparer comparer = new Comparer(Constants.SourceEmail))
            {
                comparer.Add(Constants.TargetEmail);
                comparer.Add(Constants.Target2Email);
                comparer.Add(Constants.Target3Email);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nEmail documents compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi pdf documents
        /// </summary>
        public static void CompareMultiplePdfDocuments()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsPath-CompareMultiplePdfDocuments : Comparing of multiple Pdf documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultPdf);

            using (Comparer comparer = new Comparer(Constants.SourcePdf))
            {
                comparer.Add(Constants.TargetPdf);
                comparer.Add(Constants.Target2Pdf);
                comparer.Add(Constants.Target3Pdf);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions());
            }
            Console.WriteLine($"\nPDF documents compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates comparing of multi diagram documents
        /// </summary>
        public static void CompareMultipleDiagramDocuments()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CompareMultipleDocumentsPath-CompareMultipleDiagramDocuments : Comparing of multiple diagram documents\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultDiagram);

            using (Comparer comparer = new Comparer(Constants.SourceDiagram))
            {
                comparer.Add(Constants.TargetDiagram);
                comparer.Add(Constants.Target2Diagram);
                comparer.Add(Constants.Target3Diagram);

                comparer.Compare(File.Create(outputFileName), new SaveOptions(), new CompareOptions() { DiagramMasterSetting = new DiagramMasterSetting() { MasterPath = Constants.DiagramSettings } });
            }
            Console.WriteLine($"\nDiagram documents compared successfully.\nCheck output in {outputDirectory}.");
        }

    }
}
