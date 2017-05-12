'ExStart:CommonComparisionClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Text
Imports GroupDocs.Comparison.Text.Contracts
Imports GroupDocs.Comparison.Common.Changes

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class CommonComparision
        Private Sub New()
        End Sub
        'ExStart:CompareDcumentsFromStreamToOutputStream
        ''' <summary>
        ''' Compare two documents from streams with saving results into a stream
        ''' </summary>
        Public Shared Sub CompareDcumentsFromStreamToOutputStream()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(sourceStream, targetStream, New ComparisonSettings())

            ' get result document as stream.
            Dim stream As Stream = result.GetStream()

            sourceStream.Close()
            targetStream.Close()
            stream.Close()
        End Sub
        'ExEnd:CompareDcumentsFromStreamToOutputStream

        'ExStart:CompareDcumentsFromStreamToOutputFile
        ''' <summary>
        ''' Compare two documents from streams with saving results into a file.
        ''' </summary>
        Public Shared Sub CompareDcumentsFromStreamToOutputFile()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(sourceStream, targetStream, New ComparisonSettings())

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareDcumentsFromStreamToOutputFile

        'ExStart:CompareDcumentsFromPathToOutputStream
        ''' <summary>
        ''' Compare two documents from file path with saving results into a stream
        ''' </summary>
        Public Shared Sub CompareDcumentsFromPathToOutputStream()
            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), New ComparisonSettings())

            ' get result document as stream.
            Dim stream As Stream = result.GetStream()

            stream.Close()
        End Sub
        'ExEnd:CompareDcumentsFromPathToOutputStream

        'ExStart:CompareDcumentsFromPathToOutputFile
        ''' <summary>
        ''' Compare two documents from file path with saving results into a file
        ''' </summary>
        Public Shared Sub CompareDcumentsFromPathToOutputFile()
            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), New ComparisonSettings())

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareDcumentsFromPathToOutputFile

        'ExStart:CompareDcumentsFromStreamToOutputFileWithSettings
        ''' <summary>
        ''' Compare two documents from streams with saving results into a file with comparison settings
        ''' </summary>
        Public Shared Sub CompareDcumentsFromStreamToOutputFileWithSettings()
            ' Create two streams of documents
            Dim sourceStream As Stream = File.Open(Path.Combine(Common.sourcePath, Common.sourceFile), FileMode.Open, FileAccess.Read)
            Dim targetStream As Stream = File.Open(Path.Combine(Common.targetPath, Common.targetFile), FileMode.Open, FileAccess.Read)

            ' define and set comparison settings and properties.
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow


            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(sourceStream, targetStream, objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))

            sourceStream.Close()
            targetStream.Close()
        End Sub
        'ExEnd:CompareDcumentsFromStreamToOutputFileWithSettings

        'ExStart:CompareDcumentsFromFileToOutputFileWithSettings
        ''' <summary>
        ''' Compare two documents from file path with saving results into a file with comparison settings
        ''' </summary>
        Public Shared Sub CompareDcumentsFromFileToOutputFileWithSettings()
            ' define and set comparison settings and properties.
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow


            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareDcumentsFromFileToOutputFileWithSettings


        'ExStart:CompareEncryptedFilesToOutputFileWithSettings
        ''' <summary>
        ''' Compare two encrypted/password protected documents from file path with saving results into a file with comparison settings
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesToOutputFileWithSettings()
            ' define and set comparison settings and properties.
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow


            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()
            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareEncryptedFilesToOutputFileWithSettings

        'ExStart:CompareMultipleDcumentsFromFileToOutputFileWithSettings
        ''' <summary>
        ''' Compare multiple (e.g 3) documents from file path with saving results into a file with comparison settings
        ''' </summary>
        Public Shared Sub CompareMultipleDcumentsFromFileToOutputFileWithSettings()
            ' define and set comparison settings and properties.
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow

            ' source file to compare.
            Dim source As String = Path.Combine(Common.sourcePath, Common.sourceFile)

            ' target files to compare with.
            Dim targets As New List(Of String)() From { _
             Path.Combine(Common.targetPath, Common.targetFile), _
             Path.Combine(Common.targetPath, "target1.docx"), _
             Path.Combine(Common.targetPath, "target2.docx") _
            }
            ' Get instance of GroupDocs.Comparison.MultiComparer and call method Compare.
            Dim comparison As New GroupDocs.Comparison.MultiComparer()

            Dim result As ICompareResult = comparison.Compare(source, targets, objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareMultipleDcumentsFromFileToOutputFileWithSettings

        'ExStart:CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings
        ''' <summary>
        ''' Compare multiple (e.g 3) encrypted/password protected documents from file path with saving results into a file with comparison settings
        ''' </summary>
        Public Shared Sub CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings()
            ' define and set comparison settings and properties.
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangedItemsStyle.Color = System.Drawing.Color.Yellow

            ' source file to compare.
            Dim source As String = Path.Combine(Common.sourcePath, Common.sourceFile)

            ' target files to compare with.
            Dim targets As New List(Of String)() From { _
             Path.Combine(Common.targetPath, Common.targetFile), _
             Path.Combine(Common.targetPath, "target1.docx"), _
             Path.Combine(Common.targetPath, "target2.docx") _
            }

            ' target files passwords to compare with.
            Dim targetsPasswords As New List(Of String)() From { _
             Path.Combine(Common.targetPath, Common.targetFilePassword), _
             Path.Combine(Common.targetPath, "secret"), _
             Path.Combine(Common.targetPath, "secret") _
            }
            ' Get instance of GroupDocs.Comparison.MultiComparer and call method Compare.
            Dim comparison As New GroupDocs.Comparison.MultiComparer()

            Dim result As ICompareResult = comparison.Compare(source, Common.sourceFilePassword, targets, targetsPasswords, objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareMultipleEncryptedDcumentsFromFileToOutputFileWithSettings

        'ExStart:CompareDcumentsToGetChanges
        ''' <summary>
        ''' Compare two documents from file path with saving results into a file with document settings and allow to get changes, update changes
        ''' </summary>
        Public Shared Sub CompareDcumentsToGetChanges()
            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()

            ' Define comparison settings
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangeDetection = True
            objComparisonSettings.ShowDeletedContent = True
            objComparisonSettings.GenerateSummaryPage = True

            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))

            'Get array of changes
            Dim changes As ChangeInfo() = result.GetChanges()

            'Set actions of changes as Accept or Reject
            changes(0).Action = ComparisonAction.Accept
            changes(1).Action = ComparisonAction.Reject

            'Update changes in CompareResult object (this method updated result document)
            result.UpdateChanges(changes)
        End Sub
        'ExEnd:CompareDcumentsToGetChanges

        'ExStart:CompareDcumentsToGetDocumentImages
        ''' <summary>
        ''' Compare two documents from file path with saving results into a file with document settings and get result images.
        ''' </summary>
        Public Shared Sub CompareDcumentsToGetDocumentImages()
            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()

            ' Define comparison settings
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangeDetection = True
            objComparisonSettings.ShowDeletedContent = True
            objComparisonSettings.GenerateSummaryPage = True

            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))

            'Get images of result document as array of streams 
            Dim imgStreams As Stream() = result.GetImages()
        End Sub
        'ExEnd:CompareDcumentsToGetDocumentImages

        'ExStart:CompareDcumentsToGetDocumentImagesInFolder
        ''' <summary>
        ''' Compare two documents from file path with saving results into a file with document settings and get result images into a folder.
        ''' </summary>
        Public Shared Sub CompareDcumentsToGetDocumentImagesInFolder()
            ' Get instance of GroupDocs.Comparison.Comparer and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparer = Common.getComparison()


            ' Define comparison settings
            Dim objComparisonSettings As New ComparisonSettings()
            objComparisonSettings.StyleChangeDetection = True
            objComparisonSettings.ShowDeletedContent = True
            objComparisonSettings.GenerateSummaryPage = True

            Dim result As ICompareResult = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), objComparisonSettings)

            ' save result document to a file.
            result.SaveDocument(Path.Combine(Common.resultPath, Common.resultFile))

            'Save images of result document to folder
            result.SaveImages(Common.resultPath)
        End Sub
        'ExEnd:CompareDcumentsToGetDocumentImagesInFolder
    End Class
End Namespace
'ExEnd:CommonComparisionClass
