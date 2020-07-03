---
id: groupdocs-comparison-for-net-20-2-release-notes
url: comparison/net/groupdocs-comparison-for-net-20-2-release-notes
title: GroupDocs.Comparison for .NET 20.2 Release Notes
weight: 19
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 20.2{{< /alert >}}

## Major Features

Below the list of changes in release of GroupDocs.Comparison for .NET 20.2:

*   Added ability to compare the most popular scripts and programming languages files 
*   Implemented ability to compare more than two SpreadSheet documents
*   Implemented ability to compare more than two Note documents
*   Included all supported file fromats
*   Improve calculating of coordinates of changes for PDF
*   Fixed element movement changes detection for Presentation(Slides) documents
    

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2188  | Implement Groovy files comparing | Feature |
| COMPARISONNET-2187  | Implement JSON files comparing | Feature |
| COMPARISONNET-2186  | Implement comparing ActionScipt files | Feature |
| COMPARISONNET-2185 | Implement Perl files comparing | Feature |
| COMPARISONNET-2184  | Implement comparing Objctive C\\C++ files | Feature |
| COMPARISONNET-2180  | Implement comparing Ruby files | Feature |
| COMPARISONNET-2179  | Implement Shell\\batch script, Log, Diff, Config, LESS files comparing | Feature |
| COMPARISONNET-2178  | Implement comparing PHP files | Feature |
| COMPARISONNET-2177  | Implement comparing SQL files | Feature |
| COMPARISONNET-2176  | Implement comparing C-based files | Feature |
| COMPARISONNET-2175  | Implement comparing Scala files | Feature |
| COMPARISONNET-2174  | Implement comparing Javascript files | Feature |
| COMPARISONNET-2173  | Implement comparing Assembler files | Feature |
| COMPARISONNET-2172  | Implement comparing Python files | Feature |
| COMPARISONNET-2171  | Implement comparing java files | Feature |
| COMPARISONNET-2169 | Implement comparing CSharp files | Feature |
| COMPARISONNET-2165  | Implement Multicomparer for Cells | Feature |
| COMPARISONNET-2103  | Implement Multi Comparer for Note | Feature |
| COMPARISONNET-2183  | Improve calculating of coordinates of changes for PDF | Improvement |
| COMPARISONNET-2168  | Update GetSupportedFileTypes method so it will contain all supported formats from documentation | Improvement |
| COMPARISONNET-2181  | Compare PPT/PPTX documents with element movement changes detection | Bug |
| COMPARISONNET-2097 | PDF comparison, output document title getting distorted | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 20.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  **Compare more than two Note documents**
    
    Starting from version 20.2 GroupDocs.Comparison allows to compare more than two OneNote documents (Microsoft OneNote documents for creating and exchanging notes) this functionality works for .one files.
    
    Following code snippet shows how to do this, here we are comparing 3 Note files
    
    ```csharp
    string sourcePath = "source.one";
    string target1Path = "target1.one";
    string target2Path = "target2.one";
    string target3Path = "target3.one";
    string resultPath = "result.one";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
    
2.  **Compare more than two SpreadSheet documents**
    
    Starting from version 20.2 GroupDocs.Comparison allows to compare more than two SpreadSheed documents (including spreadsheet file format created by Microsoft for use with Microsoft Excel, and ODS  - spreadsheet file format used by OpenOffice/StarOffice).
    
    This functionality works for "xls", "xlsx", "xlsb", "csv", "ods", "xls2003", "xlsm" files
    
    Following code snippet shows how to do this, here we are comparing 3 Excell files
    
    ```csharp
    string sourcePath = "source.xlsx";
    string target1Path = "target1.xlsx";
    string target2Path = "target2.xlsx";
    string target3Path = "target3.xlsx";
    string resultPath = "result.pdf";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
