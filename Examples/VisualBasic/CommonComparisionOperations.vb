
'ExStart:CommonComparisionOperationsClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.ComparisonSettings
Imports GroupDocs.Comparison.Words.Contracts
Imports GroupDocs.Comparison.Words.Contracts.Enums
Imports GroupDocs.Comparison.Words.Contracts.Nodes
Imports GroupDocs.Comparison.Words.Nodes

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class CommonComparisionOperations
        Private Sub New()
        End Sub
#Region "Common operations with automatic file format detection"

        'ExStart:CompareWithAutomaticFormatDetectionFromPath
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a stream
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPath()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile))
        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPath

        'ExStart:CompareWithAutomaticFormatDetectionFromPathToFile
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a file
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPathToFile

        'ExStart:CompareWithAutomaticFormatDetectionFromPathToFileWithExtension
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a file with extension
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPathToFileWithExtension()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), FileType.Docx)
        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPathToFileWithExtension

        'ExStart:CompareWithAutomaticFormatDetectionFromPathWithSettings
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a stream with comparison settings
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPathWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), New WordsComparisonSettings())
        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPathWithSettings

        'ExStart:CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a stream with comparison type and settings
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), ComparisonType.Words, New WordsComparisonSettings())
        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPathWithSettingsAndType

        'ExStart:CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType
        ''' <summary>
        ''' Compare two documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
        ''' </summary>
        Public Shared Sub CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Path.Combine(Common.targetPath, Common.targetFile), Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, New WordsComparisonSettings(), FileType.Docx)

            ' Get all changes
            Dim changes As GroupDocs.Comparison.Common.Changes.ChangeInfo() = comparison.GetChanges()
            If changes IsNot Nothing Then
                For Each change As GroupDocs.Comparison.Common.Changes.ChangeInfo In changes
                    Console.WriteLine("Page ID: " + change.Page.Id.ToString() + " Page Height:" + change.Page.Height.ToString() + " Width:" + change.Page.Width.ToString())
                    Console.WriteLine("Change Type: " + change.Type.ToString())
                    ' to get style changes
                    'change.StyleChanges
                    Console.WriteLine("Change Text: " + change.Text)
                Next
            End If

            Console.WriteLine("Press any key to exit")
            Console.ReadKey()

        End Sub
        'ExEnd:CompareWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType

#End Region

#Region "Common comparison operations with encrypted files"

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPath
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a stream
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPath()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Common.targetFilePassword)
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPath

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a file
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile))
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFile

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a file with extension
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile), FileType.Docx)
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtension

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison settings
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, New WordsComparisonSettings())
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettings

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a stream with comparison type and settings
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, ComparisonType.Words, New WordsComparisonSettings())
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathWithSettingsAndType

        'ExStart:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType
        ''' <summary>
        ''' Compare two encrypted documents from file path with automatic format detection with saving results into a file with comparison type and settings and file extension
        ''' </summary>
        Public Shared Sub CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType()
            ' Get instance of GroupDocs.Comparison.Comparison and call method Compare.
            Dim comparison As GroupDocs.Comparison.Comparison = Common.getComparison()
            Dim result As Stream = comparison.Compare(Path.Combine(Common.sourcePath, Common.sourceFile), Common.sourceFilePassword, Path.Combine(Common.targetPath, Common.targetFile), Common.targetFilePassword, Path.Combine(Common.resultPath, Common.resultFile), ComparisonType.Words, _
             New WordsComparisonSettings(), FileType.Docx)

            ' Get all changes
            Dim changes As GroupDocs.Comparison.Common.Changes.ChangeInfo() = comparison.GetChanges()
            If changes IsNot Nothing Then
                For Each change As GroupDocs.Comparison.Common.Changes.ChangeInfo In changes
                    Console.WriteLine("Page ID: " + change.Page.Id.ToString() + " Page Height:" + change.Page.Height.ToString() + " Width:" + change.Page.Width.ToString())
                    Console.WriteLine("Change Type: " + change.Type.ToString())
                    ' to get style changes
                    'change.StyleChanges
                    Console.WriteLine("Change Text: " + change.Text)
                Next
            End If

            Console.WriteLine("Press any key to exit")
            Console.ReadKey()
        End Sub
        'ExEnd:CompareEncryptedFilesWithAutomaticFormatDetectionFromPathToFileWithExtensionSettingsAndType


#End Region
    End Class
End Namespace
'ExEnd:CommonComparisionOperationsClass
