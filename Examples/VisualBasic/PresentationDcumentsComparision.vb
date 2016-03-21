'ExStart:PresentationDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Slides
Imports GroupDocs.Comparison.Slides.Contracts
Imports GroupDocs.Comparison.Slides.Contracts.Comparison
Imports GroupDocs.Comparison.Slides.Contracts.Enums

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class PresentationDcumentsComparision
        Private Sub New()
        End Sub

        'ExStart:ComparePresentationFromStreamToFile
        ''' <summary>
        ''' Compare two Presentation from streams with saving results into a file
        ''' </summary>
        Public Shared Sub ComparePresentationFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides)

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:ComparePresentationFromStreamToFile

        'ExStart:ComparePresentationFromPathToFile
        ''' <summary>
        ''' Compare two Presentation from file path with saving results into a file
        ''' </summary>
        Public Shared Sub ComparePresentationFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides)
        End Sub
        'ExEnd:ComparePresentationFromPathToFile

        'ExStart:ComparePresentationFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two Presentation from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub ComparePresentationFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides, New SlidesComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:ComparePresentationFromStreamToFileWithSettings

        'ExStart:ComparePresentationFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two Presentation from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub ComparePresentationFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Slides, New SlidesComparisonSettings())
        End Sub
        'ExEnd:ComparePresentationFromPathToFileWithSettings
    End Class
End Namespace
'ExEnd:PresentationDcumentsComparisionClass