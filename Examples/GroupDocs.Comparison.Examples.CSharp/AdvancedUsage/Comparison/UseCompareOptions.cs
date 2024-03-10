using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.AdvancedUsage.Comparison
{
    using GroupDocs.Comparison;
    using GroupDocs.Comparison.Options;

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
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # IgnoreHeaderFooter : how to ignore Header/Footer\n");

            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "IgnoreHeaderFooter");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_WITH_FOOTER))
            {
                CompareOptions compareOptions = new CompareOptions();
                compareOptions.HeaderFootersComparison = false;

                comparer.Add(Constants.TARGET_WITH_FOOTER);
                comparer.Compare(File.Create(outputFileName), new SaveOptions(), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to set output paper size
        /// </summary>
        public static void SetOutputPaperSize()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # SetOutputPaperSize : how to set output paper size\n");

            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "SetOutputPaperSize");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_COMPARE_OPTIONS))
            {
                comparer.Add(Constants.TARGET_COMPARE_OPTIONS);
                comparer.Compare(File.Create(outputFileName), new CompareOptions() { PaperSize = PaperSize.A6 });
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates comparing of two documents using sensitivity option
        /// </summary>
        public static void AdjustComparisonSensitivity()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # AdjustComparisonSensitivity : comparing of two documents using sensitivity option\n");

            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "AdjustComparisonSensitivity");
            string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

            using (Comparer comparer = new Comparer(Constants.SOURCE_COMPARE_OPTIONS))
            {
                comparer.Add(Constants.TARGET_COMPARE_OPTIONS);
                comparer.Compare(File.Create(outputFileName), new CompareOptions() { SensitivityOfComparison = 100 });
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to customized change styles from path
        /// </summary>
        public static void CustomizeChangesStylesStream()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CustomizeChangesStylesStream : how to customized change styles from path\n");

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
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to customized change styles from path
        /// </summary>
        public static void CustomizeChangesStylesPath()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # CustomizeChangesStylesPath : how to customized change styles from path\n");

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
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to get only one page of comparison summary information.
        /// </summary>
        public static void GetOnlySummaryPage()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # IgnoreHeaderFooter : how to ignore Header/Footer\n");

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
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to get extended comparison information
        /// </summary>
        public static void GetExtendedSummaryPage()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - GetExtendedSummaryPage : how to get extended comparison information\n");

            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "GetExtendedSummaryPage");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        //To get extended information about comparison, the GenerateSummaryPage property must be set to true
		        CompareOptions compareOptions = new CompareOptions()
		        {
                    //Added Extended information about words and sybols count. For diagrams also showing count of shapes. For HTML count of Tags.
                    GenerateSummaryPage = true,
			        ExtendedSummaryPage = true
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
        
        /// <summary>
        /// This example demonstrates how to activate compare Variable, Built and Custom properties 
        /// </summary>
        public static void CompareDocumentProperties()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - CompareDocumentProperties : how to activate compare Variable, Built and Custom properties\n");

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
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to activate compare Bookmarks
        /// </summary>
        public static void CompareBookmarks()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - CompareBookmarks : how to activate compare Bookmarks\n");

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
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to disable show revision in the result document
        /// </summary>
        public static void DisableShowRevisions()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - DisableShowRevisions : how to disable show revision in the result document\n");

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
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to replace changed content with empty lines in the result document 
        /// </summary>
        public static void LeaveGaps()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - LeaveGaps : how to replace changed content with empty lines in the result document\n");

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
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }

        /// <summary>
        /// This example demonstrates how to use the Microsoft Word "Track Changes" comparing as a built in feature in GroupDocs.Comparison for .NET. 
        /// </summary>
        public static void WordTrackChanges()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Example Advanced Usage] # Use Compare Options - WordTrackChanges : how to use the Microsoft Word \"Track Changes\" comparing\n");

            string outputDirectory = Constants.GetOutputDirectoryPath(nameChildFolder: "WordTrackChanges");
	        string outputFileName = Path.Combine(outputDirectory, Constants.RESULT_WORD);

	        using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_COMPARE_OPTIONS)))
	        {
		        comparer.Add(File.OpenRead(Constants.TARGET_COMPARE_OPTIONS));

		        CompareOptions compareOptions = new CompareOptions()
		        {
			        WordTrackChanges = true,
		        };
		        comparer.Compare(File.Create(outputFileName), compareOptions);
	        }
	        Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
