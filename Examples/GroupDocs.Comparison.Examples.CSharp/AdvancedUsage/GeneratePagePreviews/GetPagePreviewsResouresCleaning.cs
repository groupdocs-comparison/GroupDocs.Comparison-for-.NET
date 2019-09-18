using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how to get document previews with user memory clean code
    /// </summary>
    class GetPagePreviewsResouresCleaning
    {
        /// <summary>
        /// User example code for releasing image stream memory
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="stream"></param>
        private static void UserReleaseStreamMethod(int pageNumber, Stream stream)
        {
            Console.WriteLine($"Releasing memory for page: {pageNumber}");
            stream.Close();
        }

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
                previewOptions.ReleasePageStream = UserReleaseStreamMethod;
                document.GeneratePreview(previewOptions);
            }
            Console.WriteLine($"\nDocument previews generated successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
