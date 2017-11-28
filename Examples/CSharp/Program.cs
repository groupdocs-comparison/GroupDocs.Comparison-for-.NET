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
            Common.licensePath = Path.Combine(Environment.CurrentDirectory, @"D:/GroupDocs.Total.lic"); 
            //Common.ApplyLicense(Common.licensePath);

            // Uncomment following lines and specify the licence file to embed product licence using stream.
            // Stream licenseStream = File.Open(Path.Combine(Environment.CurrentDirectory, @"GroupDocs.Total.lic"), FileMode.Open, FileAccess.Read);
            // Common.ApplyLicense(licenseStream);
            // licenseStream.Close();

            ////// *** Documents Comparision Examples (Un-Comment to run each example demo methods) ***

            // Compare two documents from streams with saving results into a stream
           // CommonComparision.CompareDcumentsFromStreamToOutputStream();

           // Compare two documents from streams with saving results into a file.
          // Common.resultFile = "Comapre-result.pdf";
           //CommonComparision.CompareDcumentsFromStreamToOutputFile();

            // Compare two documents from file path with saving results into a stream
            //CommonComparision.CompareDcumentsFromPathToOutputStream();

            // Compare two documents from file path with saving results into a file
            //Common.resultFile = "result-changes.docx";
            //CommonComparision.CompareDcumentsFromPathToOutputFile();

            // Compare two documents from streams with saving results into a file with comparison settings
            //Common.resultFile = "result-CompareDcumentsFromStreamToOutputFileWithSettings.doc";
            //CommonComparision.CompareDcumentsFromStreamToOutputFileWithSettings();

            // Compare two documents from file path with saving results into a file with comparison settings
            //Common.resultFile = "result-CompareDcumentsFromFileToOutputFileWithSettings.doc";
            //CommonComparision.CompareDcumentsFromFileToOutputFileWithSettings();

            // Compare two encrypted/password protected documents from file path with saving results into a file with comparison settings
            //Common.resultFile = "result-CompareEncryptedFilesToOutputFileWithSettings.doc";
            // source and target encrypted file passwords
            //Common.sourceFilePassword = "secret";
            //Common.targetFilePassword = "secret";
            //CommonComparision.CompareEncryptedFilesToOutputFileWithSettings();

            // Compare multiple (e.g 3) documents from file path with saving results into a file with comparison settings
            //Common.resultFile = "result-CompareMultipleDcumentsFromFileToOutputFileWithSettings.doc";
            //CommonComparision.CompareMultipleDcumentsFromFileToOutputFileWithSettings();

            // Compare multiple (e.g 3) encrypted/password protected documents from file path with saving results into a file with comparison settings
            //Common.resultFile = "result-CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings.doc";
            // source and target encrypted file passwords
            //Common.sourceFilePassword = "secret";
            //Common.targetFilePassword = "secret"; // not: setting this for first file others in method definition
            //CommonComparision.CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings();

            // Compare two documents from file path with saving results into a file with document settings and allow to get changes, update changes
            //Common.resultFile = "result-CompareDcumentsToGetChanges.doc";
            //CommonComparision.CompareDcumentsToGetChanges();

            // Compare two documents from file path with saving results into a file with document settings and get result images.
            //Common.resultFile = "result-CompareDcumentsToGetDocumentImages.doc";
            //CommonComparision.CompareDcumentsToGetDocumentImages();

            // Compare two documents from file path with saving results into a file with document settings and get result images into a folder.
            //Common.resultFile = "result-CompareDcumentsToGetDocumentImagesInFolder.doc";
            //Common.resultPath = Path.Combine(Environment.CurrentDirectory, @"../../../Data/OutputFiles");
            //CommonComparision.CompareDcumentsToGetDocumentImagesInFolder();

        }
    }
}
