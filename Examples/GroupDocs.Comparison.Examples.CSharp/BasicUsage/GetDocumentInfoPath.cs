using System;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    using GroupDocs.Comparison.Interfaces;
    /// <summary>
    /// This example demonstrates document info extraction
    /// </summary>
    class GetDocumentInfoPath
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                IDocumentInfo info = comparer.Source.GetDocumentInfo();
                Console.WriteLine("\nFile type: {0}\nNumber of pages: {1}\nDocument size: {2} bytes", info.FileType, info.PageCount, info.Size);
            }
            Console.WriteLine($"\nDocument info extracted successfully.");
        }
    }
}