'ExStart:CommonClass
Imports System.IO
Imports System.Collections.Generic
Imports GroupDocs.Comparison.Common
Imports GroupDocs.Comparison.Common.License
Imports System.Reflection

Namespace GroupDocsComparisonExamples.VisualBasic
    Public NotInheritable Class Common
        Private Sub New()
        End Sub
        'ExStart:CommonProperties
        ' storagePath property to set source file/s directory
        Public Shared sourcePath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/SourceFiles/")

        ' cachePath property to set target file/s directory
        Public Shared targetPath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/TargetFiles/")

        ' outputPath property to set output file/s directory
        Public Shared resultPath As String = Path.Combine(Environment.CurrentDirectory, "../../../../Data/OuputFiles")

        ' licensePath property to set GroupDocs.Comparison license file anme and path
        Public Shared licensePath As String = Path.Combine(Environment.CurrentDirectory, "GroupDocs.comparison.lic")

        ' sourceFile property to set input source file
        Public Shared sourceFile As String = "source.docx"

        ' targetFile property to set input target file
        Public Shared targetFile As String = "target.docx"

        ' targetFile property to set input target file
        Public Shared resultFile As String = "result.doc"

        ' Create object of GroupDocs.Comparison.Comparison
        Public Shared comparison As GroupDocs.Comparison.Comparison

        'ExEnd:CommonProperties

        'ExStart:getComparison
        ''' <summary>
        ''' Get GroupDocs ConversionHandler Object
        ''' </summary>
        ''' <returns>ConversionHandler</returns>
        Public Shared Function getComparison() As GroupDocs.Comparison.Comparison
            If comparison Is Nothing Then
                ' Create instance of GroupDocs.Comparison.Comparison to call method Compare.
                comparison = New GroupDocs.Comparison.Comparison()
            End If

            ' Returns the ConversionHandler static object
            Return comparison
        End Function
        'ExEnd:getComparison

        'ExStart:ApplyLicense
        ''' <summary>
        ''' Applies GroupDocs.Comparison license
        ''' </summary>
        Public Shared Sub ApplyLicense(filepath As String)
            ' Instantiate GroupDocs.Comparison license
            Dim license As New GroupDocs.Comparison.Common.License.License()

            ' Apply GroupDocs.Comparison license using license path
            license.SetLicense(filepath)
        End Sub

        ''' <summary>
        ''' Applies GroupDocs.Comparison license using stream input
        ''' </summary>
        Public Shared Sub ApplyLicense(licenseStream As Stream)
            ' Instantiate GroupDocs.Comparison license
            Dim license As New GroupDocs.Comparison.Common.License.License()

            ' Apply GroupDocs.Comparison license using license file stream
            license.SetLicense(licenseStream)
        End Sub
        'ExEnd:ApplyLicense
    End Class

End Namespace
'ExEnd:CommonClass