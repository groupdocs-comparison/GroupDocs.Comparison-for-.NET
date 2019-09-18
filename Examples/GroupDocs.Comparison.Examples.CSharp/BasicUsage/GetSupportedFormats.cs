using GroupDocs.Comparison.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates file types support
    /// </summary>
    internal class GetSupportedFormats
    {
        public static void Run()
        {
            IEnumerable<FileType> fileTypes = FileType
                    .GetSupportedFileTypes()
                    .OrderBy(fileType => fileType.Extension);
            foreach (FileType fileType in fileTypes)
                Console.WriteLine(fileType);
            Console.WriteLine("\nSupported file types retrieved successfully.");
        }
    }
}