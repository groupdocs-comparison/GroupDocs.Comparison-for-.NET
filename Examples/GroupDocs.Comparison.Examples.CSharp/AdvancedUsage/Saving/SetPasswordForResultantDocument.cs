using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage
{
    /// <summary>
    /// This example demonstrates how protect result document by password
    /// </summary>
    class SetPasswordForResultantDocument
    {
        public static void Run()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WORD))
            {
                comparer.Add(Constants.TARGET_WORD);
                CompareOptions cOptions = new CompareOptions
                {
                    PasswordSaveOption = PasswordSaveOption.User
                };
                SaveOptions sOptions = new SaveOptions()
                {
                    Password = "3333"
                };
                comparer.Compare(outputFileName, sOptions, cOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
