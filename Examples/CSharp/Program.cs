using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /// you can set source and target file paths and output paths
            Common.sourcePath = Path.Combine(Environment.CurrentDirectory, @"../../../Data/SourceFiles");
            Common.targetPath = Path.Combine(Environment.CurrentDirectory, @"../../../Data/TargetFiles");
            Common.resultPath = Path.Combine(Environment.CurrentDirectory, @"../../../Data/OutputFiles");

            // set source and target files to compare
            Common.sourceFile = "source.docx";
            Common.targetFile = "target.docx";

            // Uncomment following lines and specify the licence file to embed product licence using file path.
            Common.licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.total.lic");
            Common.ApplyLicense(Common.licensePath);

            // Uncomment following lines and specify the licence file to embed product licence using stream.
            //Stream licenseStream = File.Open(Path.Combine(Environment.CurrentDirectory, @"GroupDocs.comparison.lic"), FileMode.Open, FileAccess.Read);
            //Common.ApplyLicense(licenseStream);
            //licenseStream.Close();

            // *** Words Comparision Examples ***

            // set source and target files to compare
            Common.sourceFile = "source.docx";
            Common.targetFile = "target.docx";

            // Compare two word processing documents from streams with saving results into a file
            Common.resultFile = "result-CompareWordDcumentsFromStreamToFile.doc";
            WordDcumentsComparision.CompareWordDcumentsFromStreamToFile();

            // Compare two word processing documents from file path with saving results into a file
            Common.resultFile = "result-CompareWordDcumentsFromPathToFile.doc";
            WordDcumentsComparision.CompareWordDcumentsFromPathToFile();

            // Compare two word processing documents from streams with saving results into a file with document settings
            Common.resultFile = "result-CompareWordDcumentsFromStreamToFileWithSettings.doc";
            WordDcumentsComparision.CompareWordDcumentsFromStreamToFileWithSettings();

            // Compare two word processing documents from file path with saving results into a file with document settings
            Common.resultFile = "result-CompareWordDcumentsFromPathToFileWithSettings.doc";
            WordDcumentsComparision.CompareWordDcumentsFromPathToFileWithSettings();


            // *** WorkBook Comparision Examples ***

            // set source and target files to compare
            Common.sourceFile = "source.xlsx";
            Common.targetFile = "target.xlsx";

            // Compare two WorkBooks from streams with saving results into a file
            Common.resultFile = "result-CompareWorkBooksFromStreamToFile.xlsx";
            WorkBookDcumentsComparision.CompareWorkBooksFromStreamToFile();

            // Compare two WorkBooks from file path with saving results into a file
            Common.resultFile = "result-CompareWorkBooksFromPathToFile.xlsx";
            WorkBookDcumentsComparision.CompareWorkBooksFromPathToFile();

            // Compare two WorkBooks from streams with saving results into a file with document settings
            Common.resultFile = "result-CompareWorkBooksFromStreamToFileWithSettings.xlsx";
            WorkBookDcumentsComparision.CompareWorkBooksFromStreamToFileWithSettings();

            // Compare two WorkBooks from file path with saving results into a file with document settings
            Common.resultFile = "result-CompareWorkBooksFromPathToFileWithSettings.xlsx";
            WorkBookDcumentsComparision.CompareWorkBooksFromPathToFileWithSettings();

            // *** Presentation Comparision Examples ***

            // set source and target files to compare
            Common.sourceFile = "source.pptx";
            Common.targetFile = "target.pptx";

            // Compare two Presentation from streams with saving results into a file
            Common.resultFile = "result-ComparePresentationFromStreamToFile.pptx";
            PresentationDcumentsComparision.ComparePresentationFromStreamToFile();

            // Compare two Presentation from file path with saving results into a file
            Common.resultFile = "result-ComparePresentationFromPathToFile.pptx";
            PresentationDcumentsComparision.ComparePresentationFromPathToFile();

            // Compare two Presentation from streams with saving results into a file with document settings
            Common.resultFile = "result-ComparePresentationFromStreamToFileWithSettings.pptx";
            PresentationDcumentsComparision.ComparePresentationFromStreamToFileWithSettings();

            // Compare two Presentation from file path with saving results into a file with document settings
            Common.resultFile = "result-ComparePresentationFromPathToFileWithSettings.pptx";
            PresentationDcumentsComparision.ComparePresentationFromPathToFileWithSettings();

            // *** Pdf Comparision Examples ***

            // set source and target files to compare
            Common.sourceFile = "source.pdf";
            Common.targetFile = "target.pdf";

            // Compare two Pdf from streams with saving results into a file
            Common.resultFile = "result-ComparePdfFromStreamToFile.pdf";
            PdfDcumentsComparision.ComparePdfFromStreamToFile();

            // Compare two Pdf from file path with saving results into a file
            Common.resultFile = "result-ComparePdfFromPathToFile.pdf";
            PdfDcumentsComparision.ComparePdfFromPathToFile();

            // Compare two Pdf from streams with saving results into a file with document settings
            Common.resultFile = "result-ComparePdfFromStreamToFileWithSettings.pdf";
            PdfDcumentsComparision.ComparePdfFromStreamToFileWithSettings();

            // Compare two Pdf from file path with saving results into a file with document settings
            Common.resultFile = "result-ComparePdfFromPathToFileWithSettings.pdf";
            PdfDcumentsComparision.ComparePdfFromPathToFileWithSettings();

            // *** Text Comparision Examples ***

            // set source and target files to compare
            Common.sourceFile = "source.txt";
            Common.targetFile = "target.txt";

            // Compare two Text from streams with saving results into a file
            Common.resultFile = "result-CompareTextDcumentsFromStreamToFile.txt";
            TextDcumentsComparision.CompareTextDcumentsFromStreamToFile();

            // Compare two Text from file path with saving results into a file
            Common.resultFile = "result-CompareTextDcumentsFromPathToFile.txt";
            TextDcumentsComparision.CompareTextDcumentsFromPathToFile();

            // Compare two Text from streams with saving results into a file with document settings
            Common.resultFile = "result-CompareTextDcumentsFromStreamToFileWithSettings.txt";
            TextDcumentsComparision.CompareTextDcumentsFromStreamToFileWithSettings();

            // Compare two Text from file path with saving results into a file with document settings
            Common.resultFile = "result-CompareTextDcumentsFromPathToFileWithSettings.txt";
            TextDcumentsComparision.CompareTextDcumentsFromPathToFileWithSettings();

        }
    }
}
