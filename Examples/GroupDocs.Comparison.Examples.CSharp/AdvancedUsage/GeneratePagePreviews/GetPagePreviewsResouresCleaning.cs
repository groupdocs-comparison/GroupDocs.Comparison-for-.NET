using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # GetPagePreviewsResouresCleaning : how to get document previews with user memory clean code\n");

            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_SLIDES);
            
            using (Comparer comparer = new Comparer(Constants.SOURCE_SLIDES))
            {
                comparer.Add(Constants.TARGET_SLIDES);
                comparer.Compare(File.Create(outputFileName));
                Document document = new Document(File.OpenRead(outputFileName));
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
            Console.WriteLine($"\nDocument previews generated successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
