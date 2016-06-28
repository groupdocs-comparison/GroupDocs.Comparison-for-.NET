'ExStart:TextDcumentsComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Text
Imports GroupDocs.Comparison.Text.Contracts

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class HTMLDcumentsComparision
        Private Sub New()
        End Sub

        'ExStart:CompareHTMLDcumentsFromStreamToFile
        ''' <summary>
        ''' Compare two HTML documents from streams with saving results into a file
        ''' </summary>
        Public Shared Sub CompareHTMLDcumentsFromStreamToFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile))

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareHTMLDcumentsFromStreamToFile

        'ExStart:CompareHTMLDcumentsFromPathToFile
        ''' <summary>
        ''' Compare two HTML documents from file path with saving results into a file
        ''' </summary>
        Public Shared Sub CompareHTMLDcumentsFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Text)

            ' get changes
            Dim changeInfo As GroupDocs.Comparison.Common.Changes.ChangeInfo() = comparison.GetChanges()

            For Each change As GroupDocs.Comparison.Common.Changes.ChangeInfo In changeInfo
                Console.WriteLine("Tex: " + change.Text)
                ' update change with custom HTML
                change.Text = "Added text by update change."
            Next

            Console.WriteLine("apply changes and display updated stream with changes.")
            ' update changes
            result = comparison.UpdateChanges(changeInfo, FileType.Html)
        End Sub
        'ExEnd:CompareHTMLDcumentsFromPathToFile

        'ExStart:CompareHTMLDcumentsFromStreamToFileWithSettings
        ''' <summary>
        ''' Compare two HTML documents from streams with saving results into a file with documen settings
        ''' </summary>
        Public Shared Sub CompareHTMLDcumentsFromStreamToFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(sourceStream, targetStream, Path.Combine(Common.resultPath, Common.resultFile), New HtmlComparisonSettings())

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareHTMLDcumentsFromStreamToFileWithSettings

        'ExStart:CompareHTMLDcumentsFromPathToFileWithSettings
        ''' <summary>
        ''' Compare two HTML documents from file path with saving results into a file with document settings
        ''' </summary>
        Public Shared Sub CompareHTMLDcumentsFromPathToFileWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), New HtmlComparisonSettings())
        End Sub
        'ExEnd:CompareHTMLDcumentsFromPathToFileWithSettings

    End Class
End Namespace
'ExEnd:HTMLDcumentsComparisionClass
