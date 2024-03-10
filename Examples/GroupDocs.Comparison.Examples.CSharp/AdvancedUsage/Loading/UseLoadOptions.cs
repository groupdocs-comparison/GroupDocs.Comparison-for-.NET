using System;
using System.IO;
using System.Collections.Generic;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

    /// <summary>
    /// This class demonstrates how to use LoadOptions
    /// </summary>
    class UseLoadOptions
	{
		/// <summary>
		/// This example demonstrates how to load custom font for comparison
		/// </summary>
		public static void LoadCustomFonts()
		{
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # UseLoadOptions : how to load custom font for comparison\n");

            List<string> fontDirectories = new List<string>();
			// Need to set the directory of the file with the font
			fontDirectories.Add(Constants.CUSTOM_FONT);

			// Instantiate the LoadOptions object and pass in a list of directories with custom fonts
			LoadOptions loadOptions = new LoadOptions();
			loadOptions.FontDirectories = fontDirectories;

			using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD_FONT), loadOptions))
			{
				comparer.Add(File.OpenRead(Constants.TARGET_WORD_FONT));
				comparer.Compare(File.Create(Path.Combine(Constants.GetOutputDirectoryPath(), Constants.RESULT_WORD_FONT)));
			}

			Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}
	}
}
