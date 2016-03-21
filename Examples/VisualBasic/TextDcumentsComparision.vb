'ExStart:TextDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Text
Imports GroupDocs.Comparison.Text.Contracts

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class TextDcumentsComparision
        Private Sub New()
        End Sub

        'ExStart:CompareTextDcumentsFromStreamToFile
        ''' <summary>
        ''' Compare two Text processing documents from streams with saving results into a file
        ''' </summary>
        Public Shared Sub CompareTextDcumentsFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text)

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareTextDcumentsFromStreamToFile

        'ExStart:CompareTextDcumentsFromPathToFile
        ''' <summary>
        ''' Compare two Text processing documents from file path with saving results into a file
        ''' </summary>
        Public Shared Sub CompareTextDcumentsFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text)
        End Sub
        'ExEnd:CompareTextDcumentsFromPathToFile

        'ExStart:CompareTextDcumentsFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two Text processing documents from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub CompareTextDcumentsFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text, New TextComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareTextDcumentsFromStreamToFileWithSettings

        'ExStart:CompareTextDcumentsFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two Text processing documents from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub CompareTextDcumentsFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text, New TextComparisonSettings())
        End Sub
        'ExEnd:CompareTextDcumentsFromPathToFileWithSettings

    End Class
End Namespace
'ExEnd:TextDcumentsComparisionClass