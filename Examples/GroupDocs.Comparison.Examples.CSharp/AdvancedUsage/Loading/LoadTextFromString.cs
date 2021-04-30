using System;
using System.IO;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Loading
{
	/// <summary>
	/// This example demonstrates comparing of two texts loaded by string variables
	/// </summary>
	class LoadTextFromString
	{
		public static void Run()
		{
			// Pass text and instantiate LoadOptions object with set LoadText property to true (this indicates that passed string contains text to be compared, not file path)
			using (Comparer comparer = new Comparer("source text", new LoadOptions() { LoadText = true }))
			{
				// Use the same code structure, to pass second text
				comparer.Add("target text", new LoadOptions() { LoadText = true });
				comparer.Compare();
				// Call GetResultString method to get text with comparison result.
				Console.WriteLine("Result string: \n" + comparer.GetResultString());
			}
			Console.WriteLine($"\nTexts compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
		}
	}
}