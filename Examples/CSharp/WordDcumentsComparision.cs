//ExStart:WordDcumentsComparisionClass
using System;
using System.IO;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Words.Contracts;
using GroupDocs.Comparison.Words.Contracts.Enums;
using GroupDocs.Comparison.Words.Contracts.Nodes;
using GroupDocs.Comparison.Words.Nodes;

namespace GroupDocs.Comparison.Examples.CSharp
{
    class WordDcumentsComparision
    {
        //ExStart:CompareWordDcumentsFromStreamToFile
        /// <summary>
        /// Compare two word processing documents from streams with saving results into a file
        /// </summary>
        public static void CompareWordDcumentsFromStreamToFile()
        {
            // Create two streams of documents
            Assembly assembly = Common.getComparisonAssembly();
            Stream sourceStream = assembly.GetManifestResourceStream(Common.sourcePath);
            Stream targetStream = assembly.GetManifestResourceStream(Common.targetPath);

            // Create instance of GroupDocs.Comparison.Comparison and call method Compare.
            GroupDocs.Comparison.Comparison comparison = Common.getComparison();
            Stream result = comparison.Compare(sourceStream, targetStream, Common.resultPath, ComparisonType.Words, new WordsComparisonSettings());
        }
        //ExEnd:CompareWordDcumentsFromStreamToFile
    }
}
//ExEnd:WordDcumentsComparisionClass