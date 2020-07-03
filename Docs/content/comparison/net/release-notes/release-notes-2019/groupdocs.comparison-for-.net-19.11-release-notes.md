---
id: groupdocs-comparison-for-net-19-11-release-notes
url: comparison/net/groupdocs-comparison-for-net-19-11-release-notes
title: GroupDocs.Comparison for .NET 19.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 19.11{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 19.11:

*   Added option to compare documents header/footer
*   Added option for specifying paper size for output documents
*   Implemented multicomparing for Text and Email documents
*   Fixed issue with releasing document handlers
*   Improved accuracy for PDF documents comparing
*   Fixed issue with wrong result files in Cells
*   Fixed accuracy of coordinates of changes on document preview

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2072 | Add option that will allow to set output format (paper size) | Feature |
| COMPARISONNET-2069 | Implement Multi comparer for Email | Feature |
| COMPARISONNET-2068  | Implement multi comparer for Text | Feature |
| COMPARISONNET-2028  | Add Comparison option to switch header/footer comparison | Feature |
| COMPARISONNET-2094   | API is not releasing file handles | Bug |
| COMPARISONNET-2076  | Compatibility issues under .NET Standard 2.0 | Bug |
| COMPARISONNET-2071  | Difference width and height is incorrect | Bug |
| COMPARISONNET-2070   | Wrong Cells result file | Bug |
| COMPARISONNET-2014  | Unexpected amount of changes in the comparing results of a PDF-files | Bug |
| COMPARISONNET-2012   | Exception during comparing PDF-files without license | Bug |
| COMPARISONNET-1993 | Incorrect box dimensions and position | Bug |
| COMPARISONNET-1971 | Difference width and height is incorrect | Bug |

Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 19.10. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  **Multicomparing for Email documents**  
    You have ability to compare more than one target email (eml) documents.
    
    ```csharp
    string sourcePath = "source.eml";
    string target1Path = "target1.eml";
    string target2Path = "target2.eml";
    string target3Path = "target3.eml";
    string resultPath = "result.eml";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
    
2.  **Multicomparing for Text documents**  
    You have ability to compare more than one target text files.
    
    ```csharp
    string sourcePath = "source.txt";
    string target1Path = "target1.txt";
    string target2Path = "target2.txt";
    string target3Path = "target3.txt";
    string resultPath = "result.txt";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
    
3.  **Option that allows to set output format of document (paper size)**  
    
    There was  added  a new ability to adjust the paper size of the result document.
    
    A new *PaperSize* propertywas added  to CompareOptions. User can set the output document paper size by assigning this property the value from the *PaperSize* enum.
    
    If user doesn’t set *PaperSize*, it has a default value - paper size in the resulting document is the same as in the target.
    
    ```csharp
    string sourcePath = "source.docx";
    string targetPath = "target.docx";
    string resultPath = "result.docx";
     
    CompareOptions compareOptions = new CompareOptions();
    compareOptions.PaperSize = PaperSize.A4;
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(targetPath);
    comparer.Compare(File.Create(resultPath), new SaveOptions(), compareOptions);
    ```
    
4.  **Option to switch header/footer comparison**  
    
    There was added a new option to compare header and footer of documents you could set it using *HeaderFootersComparison* property in *CompareOptions*
    
    By default, this property is true. To ignore the comparison of headers and footers, you should set it to false.
    
    ```csharp
    string sourcePath = "source.pdf";
    string targetPath = "target.pdf";
    string resultPath = "source.pdf";
     
    //do not compare header/footer
    CompareOptions compareOptions = new CompareOptions();
    compareOptions.HeaderFootersComparison = false;
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(targetPath);
    comparer.Compare(File.Create(resultPath), new SaveOptions(), compareOptions);
    ```
