using GroupDocs.Comparison.Options;
using System;
using System.IO;

namespace GroupDocs.Comparison.Examples.CSharp.BasicUsage
{
    /// <summary>
    /// This example demonstrates how to customized change styles from path
    /// </summary>
    class CustomizeChangesStylesStream
    {
        public static void Run()
        {
            using (Comparer comparer = new Comparer(File.OpenRead(Constants.SOURCE_WORD)))
            {
                comparer.Add(File.OpenRead(Constants.TARGET_WORD));
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
                comparer.Compare(File.Create(Constants.RESULT_WORD), compareOptions);
            }
            Console.WriteLine($"\nDocuments compared successfully.\nCheck output in {Directory.GetCurrentDirectory()}.");
        }
    }
}