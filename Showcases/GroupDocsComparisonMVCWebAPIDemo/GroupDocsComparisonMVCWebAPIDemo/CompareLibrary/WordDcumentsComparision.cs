using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using GroupDocs.Comparison.Common;
using GroupDocs.Comparison.Common.ComparisonSettings;
using GroupDocs.Comparison.Words.Contracts;
using GroupDocs.Comparison.Words.Contracts.Enums;
using GroupDocs.Comparison.Words.Contracts.Nodes;
using GroupDocs.Comparison.Words.Nodes;
using System.IO;

namespace GroupDocsComparisonWebFormsDemo.CompareLibrary
{
    public class WordDcumentsComparision
    {
        //ExStart:CompareWordDcumentsFromStreamToFile
        /// <summary>
        /// Compare two word processing documents from streams with saving results into a file
        /// </summary>
        public static string CompareWordDcumentsFromStreamToFile(Stream sourceStream, Stream targetStream, string resultFile)
        {
            IComparisonDocument sourcePresentation = new ComparisonDocument(sourceStream);
            IComparisonDocument targetPresentation = new ComparisonDocument(targetStream);
            WordsComparisonSettings comparisonSettings = new WordsComparisonSettings();
            IWordsCompareResult compareResult = sourcePresentation.CompareWith(targetPresentation, comparisonSettings);
            // Saving result of comparison to new document
            IComparisonDocument result = compareResult.GetDocument();
            Stream resultStream = new FileStream(resultFile, FileMode.Create);

            result.Save(resultStream, ComparisonSaveFormat.Docx);
            resultStream.Close();

            return resultFile;
        }
        //ExEnd:CompareWordDcumentsFromStreamToFile
    }
}