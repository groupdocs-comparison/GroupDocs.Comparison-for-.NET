using GroupDocs.Comparison.Examples.CSharp;
using GroupDocs.Comparison.Interfaces;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates result document object info extraction
    /// </summary>
    class GetDocumentInfoFromResultDocument
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
                IDocumentInfo info = comparer.Compare().GetDocumentInfo();
                Console.WriteLine("\nFile type: {0}\nNumber of pages: {1}\nDocument size: {2} bytes", info.FileType, info.PageCount, info.Size);
            }
            Console.WriteLine($"\nDocument info extracted successfully.");
        }
    }
}


