using System.IO;
using System.Runtime.CompilerServices;

namespace GroupDocs.Comparison.Examples.CSharp
{
    internal static class Constants
    {
        static Constants()
        {
            SamplesPath = LocalSamplesPath;
            string coreSamplesPath = "../../../../GroupDocs.Comparison.Examples.CSharp/" + LocalSamplesPath;
            string frameworkSamplesPath = "../../../GroupDocs.Comparison.Examples.CSharp/" + LocalSamplesPath;
            if (Directory.Exists(coreSamplesPath))
                SamplesPath = coreSamplesPath;
            else if (Directory.Exists(frameworkSamplesPath))
                SamplesPath = frameworkSamplesPath;
            else if (!Directory.Exists(SamplesPath))
                throw new DirectoryNotFoundException("Could not find samples directory");
        }

        public const string LicensePath = "D:\\GroupDocs.Comparison.NET.lic";

        public const string OutputPath = "Results/Output";

        public const string LocalSamplesPath = "Resources/SampleFiles";

        public static string SamplesPath { get; private set; }

        public static string SourceCells => GetSampleFilePath("source.xlsx");
        public static string TargetCells => GetSampleFilePath("target.xlsx");

        public static string SourceJson => GetSampleFilePath("source.json");
        public static string TargetJson => GetSampleFilePath("target.json");
        public static string SourceWord => GetSampleFilePath("source.docx");
        public static string SourceWordFont => GetSampleFilePath("source_font.docx");
        public static string TargetWord => GetSampleFilePath("target.docx");
        public static string TargetWordFont => GetSampleFilePath("target_font.docx");
        public static string Target2Word => GetSampleFilePath("target2.docx");
        public static string Target3Word => GetSampleFilePath("target3.docx");
        public static string SourceWordProtected => GetSampleFilePath("source_protected.docx");
        public static string TargetWordProtected => GetSampleFilePath("target_protected.docx");
        public static string Target2WordProtected => GetSampleFilePath("target2_protected.docx");
        public static string Target3WordProtected => GetSampleFilePath("target3_protected.docx");

        public static string SourceSlide => GetSampleFilePath("source.pptx");
        public static string TargetSlide => GetSampleFilePath("target.pptx");

        public static string SourceTxt => GetSampleFilePath("source.txt");
        public static string TargetTxt => GetSampleFilePath("target.txt");
        public static string Target2Txt => GetSampleFilePath("target2.txt");
        public static string Target3Txt => GetSampleFilePath("target3.txt");

        public static string SourceEmail => GetSampleFilePath("source.eml");
        public static string TargetEmail => GetSampleFilePath("target.eml");
        public static string Target2Email => GetSampleFilePath("target2.eml");
        public static string Target3Email => GetSampleFilePath("target3.eml");

        public static string SourcePdf => GetSampleFilePath("source.pdf");
        public static string TargetPdf => GetSampleFilePath("target.pdf");
        public static string Target2Pdf => GetSampleFilePath("target2.pdf");
        public static string Target3Pdf => GetSampleFilePath("target3.pdf");

        public static string SourceDiagram => GetSampleFilePath("source.vsdx");
        public static string TargetDiagram => GetSampleFilePath("target.vsdx");
        public static string Target2Diagram => GetSampleFilePath("target2.vsdx");
        public static string Target3Diagram => GetSampleFilePath("target3.vsdx");

        public static string SourceImage => GetSampleFilePath("source.png");
        public static string TargetImage => GetSampleFilePath("target.png");

        public static string SourceWithFooter => GetSampleFilePath("sourceWithFooter.docx");
        public static string TargetWithFooter => GetSampleFilePath("targetWithFooter.docx");

        public static string SourceCompareOptions => GetSampleFilePath("source_compare_options.docx");
        public static string TargetCompareOptions => GetSampleFilePath("target_compare_options.docx");

        public static string SourceRevisions => GetSampleFilePath("revision.docx");

        public static string SourceFolder => GetSampleFilePath("SourceFolder");
        public static string TargetFolder => GetSampleFilePath("TargetFolder");


        public static string ResultWord => "result.docx";
        public static string ResultWithNewAuthorWord => "resultWithNewAuthor.docx";
        public static string ResultWithAcceptedChangeWord => "resultWithAcceptedChange.docx";
        public static string ResultWithRejectedChangeWord => "resultWithRejectedChange.docx";
        public static string ResultWordFont => "result_font.docx";

        public static string ResultCells => "result.xlsx";
        public static string ResultSlides => "result.pptx";
        public static string ResultTxt => "result.txt";
        public static string ResultEmail => "result.eml";
        public static string ResultPdf => "result.pdf";
        public static string ResultDiagram => "result.vsdx";
        public static string ResultImage => "result.png";
        public static string ResultRevisions => "result.docx";
        public static string ResultFolder => "ResultFolderCompare";

        public static string DiagramSettings => GetSampleFilePath("basicShapes.vssx");
        public static string CustomFont => GetSampleFilePath("");
        private static string GetSampleFilePath(string filePath) => Path.Combine(SamplesPath, filePath);

        public static string GetOutputDirectoryPath([CallerFilePath] string callerFilePath = null, string nameChildFolder = null)
        {
            string outputDirectory = Path.Combine(OutputPath, Path.GetFileNameWithoutExtension(callerFilePath));

            if (nameChildFolder != null) outputDirectory = Path.Combine(outputDirectory, nameChildFolder);

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            string path = Path.GetFullPath(outputDirectory);
            return path;
        }
    }
}