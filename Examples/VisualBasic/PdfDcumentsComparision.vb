'ExStart:PdfDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Pdf
Imports GroupDocs.Comparison.Pdf.Contracts.ComparedResult

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class PdfDcumentsComparision
        Private Sub New()
        End Sub

        'ExStart:ComparePdfFromStreamToFile
        ''' <summary>
        ''' Compare two Pdf from streams with saving results into a file
        ''' </summary>
        Public Shared Sub ComparePdfFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf)

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:ComparePdfFromStreamToFile

        'ExStart:ComparePdfFromPathToFile
        ''' <summary>
        ''' Compare two Pdf from file path with saving results into a file
        ''' </summary>
        Public Shared Sub ComparePdfFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf)
        End Sub
        'ExEnd:ComparePdfFromPathToFile

        'ExStart:ComparePdfFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two Pdf from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub ComparePdfFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf, New PdfComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:ComparePdfFromStreamToFileWithSettings

        'ExStart:ComparePdfFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two Pdf from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub ComparePdfFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Pdf, New PdfComparisonSettings())
        End Sub
        'ExEnd:ComparePdfFromPathToFileWithSettings
    End Class
End Namespace
'ExEnd:PdfDcumentsComparisionClass