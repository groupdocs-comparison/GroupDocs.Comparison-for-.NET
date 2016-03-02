'ExStart:WordDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Words.Contracts
Imports GroupDocs.Comparison.Words.Contracts.Enums
Imports GroupDocs.Comparison.Words.Contracts.Nodes
Imports GroupDocs.Comparison.Words.Nodes

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class WordDcumentsComparision
        Private Sub New()
        End Sub
        'ExStart:CompareWordDcumentsFromStreamToFile
        ''' <summary>
        ''' Compare two word processing documents from streams with saving results into a file
        ''' </summary>
        Public Shared Sub CompareWordDcumentsFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words)

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareWordDcumentsFromStreamToFile

        'ExStart:CompareWordDcumentsFromPathToFile
        ''' <summary>
        ''' Compare two word processing documents from file path with saving results into a file
        ''' </summary>
        Public Shared Sub CompareWordDcumentsFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words)
        End Sub
        'ExEnd:CompareWordDcumentsFromPathToFile

        'ExStart:CompareWordDcumentsFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two word processing documents from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub CompareWordDcumentsFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, New WordsComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareWordDcumentsFromStreamToFileWithSettings

        'ExStart:CompareWordDcumentsFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two word processing documents from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub CompareWordDcumentsFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, New WordsComparisonSettings())
        End Sub
        'ExEnd:CompareWordDcumentsFromPathToFileWithSettings
    End Class
End Namespace
'ExEnd:WordDcumentsComparisionClass