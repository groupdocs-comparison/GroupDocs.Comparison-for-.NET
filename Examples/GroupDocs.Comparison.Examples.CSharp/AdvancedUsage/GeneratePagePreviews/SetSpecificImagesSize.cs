using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to get document specific size previews
    /// </summary>
    class SetSpecificImagesSize
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(Constants.SOURCE_SLIDES))
            {
                comparer.Add(Constants.TARGET_SLIDES);
                comparer.Compare(File.Create(Constants.RESULT_SLIDES));
                Document document = new Document(File.OpenRead(Constants.RESULT_SLIDES));
                PreviewOptions previewOptions = new PreviewOptions(pageNumber =>
                {
                    var pagePath = Path.Combine(Constants.SamplesPath, $"result_{pageNumber}.png");
                    return File.Create(pagePath);
                });
                previewOptions.PreviewFormat = PreviewFormats.PNG;
                previewOptions.PageNumbers = new int[] { 1, 2 };
                previewOptions.Height = 1000;
                previewOptions.Width = 1000;
                document.GeneratePreview(previewOptions);
            }
            Console.WriteLine($"\nDocument previews generated successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
