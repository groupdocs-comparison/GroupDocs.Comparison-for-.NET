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
            Common.sourcePath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/SourceFiles/");
            Common.targetPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/TargetFiles/");
            Common.resultPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/OuputFiles");

            // set source and target files to compare
            Common.sourceFile = "source.docx";
            Common.targetFile = "target.docx";

            // Uncomment following lines and specify the licence file to embed product licence using file path.
            // Common.licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.comparison.lic");
            // Common.ApplyLicense(Common.licensePath);

            // Uncomment following lines and specify the licence file to embed product licence using stream.
            //Stream licenseStream = File.Open(Path.Combine(Environment.CurrentDirectory, @"GroupDocs.comparison.lic"), FileMode.Open, FileAccess.Read);
            //Common.ApplyLicense(licenseStream);

            // Compare two word processing documents from streams with saving results into a file
            WordDcumentsComparision.CompareWordDcumentsFromStreamToFile();
        }
    }
}
