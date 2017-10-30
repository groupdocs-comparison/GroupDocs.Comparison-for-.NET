//ExStart:CommonClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.License;
using System.Reflection;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class Common
    {
        //ExStart:CommonProperties
        // storagePath property to set source file/s directory
        public static string sourcePath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/SourceFiles/");

        // cachePath property to set target file/s directory
        public static string targetPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/TargetFiles/");

        // outputPath property to set output file/s directory
        public static string resultPath = Path.Combine(Environment.CurrentDirectory, @"../../../../Data/OuputFiles");

        // licensePath property to set GroupDocs.Comparison license file anme and path
        public static string licensePath = Path.Combine(Environment.CurrentDirectory, @"GroupDocs.comparison.lic");

        // sourceFile property to set input source file
        public static string sourceFile = "source.docx";

        // targetFile property to set input target file
        public static string targetFile = "target.docx";

        // sourceFilePassword property to set input source file password
        public static string sourceFilePassword = "pass";

        // targetFilePassword property to set input target file password
        public static string targetFilePassword = "pass";

        // targetFile property to set input target file
        public static string resultFile = "result.doc";

        // Create object of GroupDocs.Comparison.Comparer
        public static GroupDocs.Comparison.Comparer comparison = new GroupDocs.Comparison.Comparer();

        //ExEnd:CommonProperties

        //ExStart:getComparison
        /// <summary>
        /// Get GroupDocs ComparisonHandler Object
        /// </summary>
        /// <returns>ConversionHandler</returns>
        public static Comparison.Comparer getComparison()
        {
            if (comparison == null)
            {
                // Create instance of GroupDocs.Comparison.Comparer to call method Compare.
                comparison = new GroupDocs.Comparison.Comparer();
            }

            // Returns the ComparisonHandler static object
            return comparison;
        }
        //ExEnd:getComparison

        //ExStart:ApplyLicense
        /// <summary>
        /// Applies GroupDocs.Comparison license
        /// </summary>
        public static void ApplyLicense(string filepath)
        {
            // Instantiate GroupDocs.Comparison license
            GroupDocs.Comparison.Common.License.License license = new GroupDocs.Comparison.Common.License.License();

            // Apply GroupDocs.Comparison license using license path
            license.SetLicense(filepath);
        }

        /// <summary>
        /// Applies GroupDocs.Comparison license using stream input
        /// </summary>
        public static void ApplyLicense(Stream licenseStream)
        {
            // Instantiate GroupDocs.Comparison license
            GroupDocs.Comparison.Common.License.License license = new GroupDocs.Comparison.Common.License.License();

            // Apply GroupDocs.Comparison license using license file stream
            license.SetLicense(licenseStream);
        }
        //ExEnd:ApplyLicense
    }

}
//ExEnd:CommonClass