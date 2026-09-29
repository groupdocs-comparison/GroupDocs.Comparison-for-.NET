using System;
using System.Collections.Generic;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison
{
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This example demonstrates how to skip loading of external resources
    /// while allowing specific ones via <see cref="LoadOptions.WhitelistedResources"/>.
    /// </summary>
    class SkipExternalResources
    {
        public static void Run()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SkipExternalResources : how to skip external resources and whitelist specific ones\n");

            string sourceDocumentPath = Constants.SourceWord;
            string targetDocumentPath = Constants.TargetWord;
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.ResultWord);

            LoadOptions loadOptions = new LoadOptions
            {
                SkipExternalResources = true,
                WhitelistedResources = new List<string> { "includepicture-field.png" }
            };

            using (Comparer comparer = new Comparer(sourceDocumentPath, loadOptions))
            {
                comparer.Add(targetDocumentPath, loadOptions);
                comparer.Compare(outputFileName);
            }

            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputFileName}.");
        }
    }
}
