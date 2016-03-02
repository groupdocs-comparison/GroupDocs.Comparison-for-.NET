'ExStart:PresentationDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Cells.Contracts.Nodes
Imports GroupDocs.Comparison.Cells.Nodes

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class WorkBookDcumentsComparision
        Private Sub New()
        End Sub

        'ExStart:CompareWorkBooksFromStreamToFile
        ''' <summary>
        ''' Compare two WorkBooks from streams with saving results into a file
        ''' </summary>
        Public Shared Sub CompareWorkBooksFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells)

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareWorkBooksFromStreamToFile

        'ExStart:CompareWorkBooksFromPathToFile
        ''' <summary>
        ''' Compare two WorkBooks from file path with saving results into a file
        ''' </summary>
        Public Shared Sub CompareWorkBooksFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells)
        End Sub
        'ExEnd:CompareWorkBooksFromPathToFile

        'ExStart:CompareWorkBooksFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two WorkBooks from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub CompareWorkBooksFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells, New CellsComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareWorkBooksFromStreamToFileWithSettings

        'ExStart:CompareWorkBooksFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two WorkBooks from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub CompareWorkBooksFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Cells, New CellsComparisonSettings())
        End Sub
        'ExEnd:CompareWorkBooksFromPathToFileWithSettings
    End Class
End Namespace
'ExEnd:WorkBookDcumentsComparisionClass