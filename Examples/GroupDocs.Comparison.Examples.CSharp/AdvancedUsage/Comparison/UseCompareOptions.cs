using System;
using System.Collections.Generic;
using System.IO;
using GroupDocs.Comparison.Options;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison
{
    /// <summary>
    /// This class demonstrates how to use CompareOptions
    /// </summary>
    class UseCompareOptions
    {
        /// <summary>
        /// This example demonstrates how to ignore Header/Footer
        /// </summary>
        public static void IgnoreHeaderFooter()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "IgnoreHeaderFooter");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WITH_FOOTER))
            {
                CompareOptions compareOptions = new CompareOptions();
                compareOptions.HeaderFootersComparison = false;

                comparer.Add(Constants.TARGET_WITH_FOOTER);
                comparer.Compare(File.Create(outputFileName), new SaveOptions(), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to set output paper size
        /// </summary>
        public static void SetOutputPaperSize()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "SetOutputPaperSize");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_COMPARE_OPTIONS))
            {
                comparer.Add(Constants.TARGET_COMPARE_OPTIONS);
                comparer.Compare(File.Create(outputFileName), new CompareOptions() { PaperSize = PaperSize.A6 });
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates comparing of two documents using sensitivity option
        /// </summary>
        public static void AdjustComparisonSensitivity()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "AdjustComparisonSensitivity");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_COMPARE_OPTIONS))
            {
                comparer.Add(Constants.TARGET_COMPARE_OPTIONS);
                comparer.Compare(File.Create(outputFileName), new CompareOptions() { SensitivityOfComparison = 100 });
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to customized change styles from path
        /// </summary>
        public static void CustomizeChangesStylesStream()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "CustomizeChangesStylesStream");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));
                CompareOptions compareOptions = new CompareOptions()
                {
                    InsertedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Red,
                        FontColor = System.Drawing.Color.Green,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    },
                    DeletedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Azure,
                        FontColor = System.Drawing.Color.Brown,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    },
                    ChangedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Crimson,
                        FontColor = System.Drawing.Color.Firebrick,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    }
                };
                comparer.Compare(File.Create(outputFileName), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to customized change styles from path
        /// </summary>
        public static void CustomizeChangesStylesPath()
        {
            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "CustomizeChangesStylesPath"); 
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_COMPARE_OPTIONS))
            {
                comparer.Add(Constants.TARGET_COMPARE_OPTIONS);
                CompareOptions compareOptions = new CompareOptions()
                {
                    InsertedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Red,
                        FontColor = System.Drawing.Color.Green,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    },
                    DeletedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Azure,
                        FontColor = System.Drawing.Color.Brown,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    },
                    ChangedItemStyle = new StyleSettings()
                    {
                        HighlightColor = System.Drawing.Color.Crimson,
                        FontColor = System.Drawing.Color.Firebrick,
                        IsUnderline = true,
                        IsBold = true,
                        IsStrikethrough = true,
                        IsItalic = true
                    }
                };
                comparer.Compare(outputFileName, compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to get only one page of comparison summary information.
        /// </summary>
        public static void GetOnlySummaryPage()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "GetOnlySummaryPage");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        //To get only the SummaryPage, the GenerateSummaryPage property must be set to true
		        CompareOptions compareOptions = new CompareOptions()
		        {
			        GenerateSummaryPage = true,
			        ShowOnlySummaryPage = true
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to get extended comparison information
        /// </summary>
        public static void GetExtendedSummaryPage()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "GetExtendedSummaryPage");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        //To get extended information about comparison, the GenerateSummaryPage property must be set to true
		        CompareOptions compareOptions = new CompareOptions()
		        {
			        GenerateSummaryPage = true,
			        ExtendedSummaryPage = true
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
        
        /// <summary>
        /// This example demonstrates how to activate compare Variable, Built and Custom properties 
        /// </summary>
        public static void CompareDocumentProperties()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "CompareDocumentProperties");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        CompareOptions compareOptions = new CompareOptions()
		        {
			        CompareVariableProperty = true,
			        CompareDocumentProperty = true
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to activate compare Bookmarks
        /// </summary>
        public static void CompareBookmarks()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "CompareBookmarks");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        CompareOptions compareOptions = new CompareOptions()
		        {
			        CompareBookmarks = true
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to disable show revision in the result document
        /// </summary>
        public static void DisableShowRevisions()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "DisableShowRevisions");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        CompareOptions compareOptions = new CompareOptions()
		        {
			        ShowRevisions = false
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }

        /// <summary>
        /// This example demonstrates how to replace changed content with empty lines in the result document 
        /// </summary>
        public static void LeaveGaps()
        {
	        string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "LeaveGaps");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        CompareOptions compareOptions = new CompareOptions()
		        {
			        ShowInsertedContent = false,
                    ShowDeletedContent = false,
                    LeaveGaps = true,
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}
