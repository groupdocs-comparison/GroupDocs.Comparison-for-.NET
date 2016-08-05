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

            //// set source and target files to compare
            Common.sourceFile = "source.docx";
            Common.targetFile = "target.docx";

            ////// Uncomment following lines and specify the licence file to embed product licence using file path.
            Common.licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.Total.lic");
            Common.ApplyLicense(Common.licensePath);

            ////// Uncomment following lines and specify the licence file to embed product licence using stream.
            //Stream licenseStream = File.Open(Path.Combine(Environment.CurrentDirectory, @"GroupDocs.Total.lic"), FileMode.Open, FileAccess.Read);
            //Common.ApplyLicense(licenseStream);
           // licenseStream.Close();

            ////// *** Words Comparision Examples ***

            ////// set source and target files to compare
            //Common.sourceFile = "source.docx";
            //Common.targetFile = "target.docx";

            ////// Compare two word processing documents from streams with saving results into a file
            //Common.resultFile = "result-CompareWordDcumentsFromStreamToFile.pdf";
            //WordDcumentsComparision.CompareWordDcumentsFromStreamToFile();

            ////// Compare two word processing documents from file path with saving results into a file
            ////Common.resultFile = "result-CompareWordDcumentsFromPathToFile.doc";
            ////WordDcumentsComparision.CompareWordDcumentsFromPathToFile();

            ////// Compare two word processing documents from streams with saving results into a file with document settings
            //Common.resultFile = "result-CompareWordDcumentsFromStreamToFileWithSettings.doc";
            //WordDcumentsComparision.CompareWordDcumentsFromStreamToFileWithSettings();

            ////// Compare two word processing documents from file path with saving results into a file with document settings
            ////Common.resultFile = "result-CompareWordDcumentsFromPathToFileWithSettings.doc";
            //WordDcumentsComparision.CompareWordDcumentsFromPathToFileWithSettings();


            ////// *** WorkBook Comparision Examples ***

            ////// set source and target files to compare
            ////Common.sourceFile = "source.xlsx";
            ////Common.targetFile = "target.xlsx";

            ////// Compare two WorkBooks from streams with saving results into a file
            ////Common.resultFile = "result-CompareWorkBooksFromStreamToFile.xlsx";
            ////WorkBookDcumentsComparision.CompareWorkBooksFromStreamToFile();

            ////// Compare two WorkBooks from file path with saving results into a file
            ////Common.resultFile = "result-CompareWorkBooksFromPathToFile.xlsx";
            ////WorkBookDcumentsComparision.CompareWorkBooksFromPathToFile();

            ////// Compare two WorkBooks from streams with saving results into a file with document settings
            ////Common.resultFile = "result-CompareWorkBooksFromStreamToFileWithSettings.xlsx";
            ////WorkBookDcumentsComparision.CompareWorkBooksFromStreamToFileWithSettings();

            ////// Compare two WorkBooks from file path with saving results into a file with document settings
            ////Common.resultFile = "result-CompareWorkBooksFromPathToFileWithSettings.xlsx";
            ////WorkBookDcumentsComparision.CompareWorkBooksFromPathToFileWithSettings();

            ////// *** Presentation Comparision Examples ***

            ////// set source and target files to compare
            ////Common.sourceFile = "source.pptx";
            ////Common.targetFile = "target.pptx";

            ////// Compare two Presentation from streams with saving results into a file
            ////Common.resultFile = "result-ComparePresentationFromStreamToFile.pptx";
            ////PresentationDcumentsComparision.ComparePresentationFromStreamToFile();

            ////// Compare two Presentation from file path with saving results into a file
            ////Common.resultFile = "result-ComparePresentationFromPathToFile.pptx";
            ////PresentationDcumentsComparision.ComparePresentationFromPathToFile();

            ////// Compare two Presentation from streams with saving results into a file with document settings
            ////Common.resultFile = "result-ComparePresentationFromStreamToFileWithSettings.pptx";
            ////PresentationDcumentsComparision.ComparePresentationFromStreamToFileWithSettings();

            ////// Compare two Presentation from file path with saving results into a file with document settings
            ////Common.resultFile = "result-ComparePresentationFromPathToFileWithSettings.pptx";
            ////PresentationDcumentsComparision.ComparePresentationFromPathToFileWithSettings();

            ////// *** Pdf Comparision Examples ***

            ////// set source and target files to compare
            Common.sourceFile = "SHMA E-Suit Orignal.pdf";
            Common.targetFile = "SHMA E-Suit changed.pdf";

            ////// Compare two Pdf from streams with saving results into a file
            Common.resultFile = "Esuit-Compare.pdf";
            PdfDcumentsComparision.ComparePdfFromStreamToFile();

            ////// Compare two Pdf from file path with saving results into a file
            ////Common.resultFile = "result-ComparePdfFromPathToFile.pdf";
            ////PdfDcumentsComparision.ComparePdfFromPathToFile();

            ////// Compare two Pdf from streams with saving results into a file with document settings
            ////Common.resultFile = "result-ComparePdfFromStreamToFileWithSettings.pdf";
            ////PdfDcumentsComparision.ComparePdfFromStreamToFileWithSettings();

            ////// Compare two Pdf from file path with saving results into a file with document settings
            ////Common.resultFile = "result-ComparePdfFromPathToFileWithSettings.pdf";
            ////PdfDcumentsComparision.ComparePdfFromPathToFileWithSettings();

            ////// *** Text Comparision Examples ***

            ////// set source and target files to compare
            ////Common.sourceFile = "source.txt";
            ////Common.targetFile = "target.txt";

            ////// Compare two Text documents from streams with saving results into a file
            ////Common.resultFile = "result-CompareTextDcumentsFromStreamToFile.txt";
            ////TextDcumentsComparision.CompareTextDcumentsFromStreamToFile();

            ////// Compare two Text documents from file path with saving results into a file
            ////Common.resultFile = "result-CompareTextDcumentsFromPathToFile.txt";
            ////TextDcumentsComparision.CompareTextDcumentsFromPathToFile();

            ////// Compare two Text documents from streams with saving results into a file with document settings
            ////Common.resultFile = "result-CompareTextDcumentsFromStreamToFileWithSettings.txt";
            ////TextDcumentsComparision.CompareTextDcumentsFromStreamToFileWithSettings();

            ////// Compare two Text documents from file path with saving results into a file with document settings
            ////Common.resultFile = "result-CompareTextDcumentsFromPathToFileWithSettings.txt";
            ////TextDcumentsComparision.CompareTextDcumentsFromPathToFileWithSettings();


            //// *** HTML Comparision Examples ***

            //// set source and target files to compare
            //Common.sourceFile = "source.html";
            //Common.targetFile = "target.html";

            ////// Compare two HTML documents from streams with saving results into a file
            ////Common.resultFile = "result-CompareHTMLDcumentsFromStreamToFile.html";
            ////HTMLDcumentsComparision.CompareHTMLDcumentsFromStreamToFile();

            ////// Compare two HTML documents from file path with saving results into a file
            ////Common.resultFile = "result-CompareHTMLDcumentsFromPathToFile.html";
            ////HTMLDcumentsComparision.CompareHTMLDcumentsFromPathToFile();

            ////// Compare two HTML documents from streams with saving results into a file with document settings
            ////Common.resultFile = "result-CompareHTMLDcumentsFromStreamToFileWithSettings.html";
            ////HTMLDcumentsComparision.CompareHTMLDcumentsFromStreamToFileWithSettings();

            ////// Compare two HTML documents from file path with saving results into a file with document settings
            ////Common.resultFile = "result-CompareHTMLDcumentsFromPathToFileWithSettings.html";
            ////HTMLDcumentsComparision.CompareHTMLDcumentsFromPathToFileWithSettings();

            ////// *** Comparision Common Operations with automatic file format detection ***

            ////// set source and target files to compare
            //Common.sourceFile = "source.docx";
            //Common.targetFile = "target.docx";
            //Common.resultFile = "result-CompareFile.docx";

            ////// Compare two documents from file path with automatic format detection with saving results into a stream
            ////CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPath();

            ////// Compare two documents from file path with automatic format detection with saving results into a file
            ////CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPathToFile();

            ////// Compare two documents from file path with automatic format detection with saving results into a file with extension
            ////CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPathToFileWithExtension();

            ////// Compare two documents from file path with automatic format detection with saving results into a stream with comparison settings
            ////CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPathWithSettings();

            ////// Compare two documents from file path with automatic format detection with saving results into a stream with comparison type and settings
            ////CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType();

            ////// Compare two documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
            //CommonComparisionOperations.CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType();



            ////// *** Comparision Common Operations with Encrypted files***

            ////// set source and target files to compare
            //Common.sourceFile = "sourceProtected.docx";
            //Common.targetFile = "targetProtected.docx";
            //Common.resultFile = "result-ProtectedFile.docx";

            ////// source and target encrypted file passwords
            ////Common.sourceFilePassword = "secret";
            ////Common.targetFilePassword = "secret";

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a stream
            ////CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPath();

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a file
            ////CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile();

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a file with extension
            ////CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension();

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison settings
            ////CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings();

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison type and settings
            ////CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType();

            ////// Compare two encrypted documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
            //CommonComparisionOperations.CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType();
        }
    }
}
