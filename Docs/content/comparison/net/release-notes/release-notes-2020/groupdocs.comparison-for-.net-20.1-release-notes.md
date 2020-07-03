---
id: groupdocs-comparison-for-net-20-1-release-notes
url: comparison/net/groupdocs-comparison-for-net-20-1-release-notes
title: GroupDocs.Comparison for .NET 20.1 Release Notes
weight: 20
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 20.1{{< /alert >}}{{< alert style="danger" >}}In this version we will remove Legacy API of GroupDocs.Comparison. So from version 20.1 GroupDocs.Comparison.Legacy. does not exist anymore{{< /alert >}}

## Major Features

Below is the list of most notable changes in release of GroupDocs.Comparison for .NET 20.1:

*   Removed legacy API  
*   Implemented comparing more than 2 PDF documents
*   Implemented comparing more than 2 Diagrams documents
*   Improve table comparison in PDF
*   Fixed error when comparing two identical Word documents 

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2104 | Implement Multicomparer for Diagram | Feature |
| COMPARISONNET-2105  | Implement Multicomparer for PDF | Feature |
| COMPARISONNET-2133  | Improve table comparison in PDF | Improvement |
| COMPARISONNET-2148  | Error occurred in comparing two identical Word documents | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 20.1. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

*   **Multicomparing for Diagrams documents**  
    You have ability to compare more than one target diagram (vsdx) documents
    
    ```csharp
    string sourcePath = "source.vsdx";
    string target1Path = "target1.vsdx";
    string target2Path = "target2.vsdx";
    string target3Path = "target3.vsdx";
    string resultPath = "result.vsdx";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
    
*   **Multicomparing for PDF documents**
    
    You have ability to compare more than one target PDF documents
    
    ```csharp
    string sourcePath = "source.pdf";
    string target1Path = "target1.pdf";
    string target2Path = "target2.pdf";
    string target3Path = "target3.pdf";
    string resultPath = "result.pdf";
     
    Comparer comparer = new Comparer(sourcePath);
    comparer.Add(target1Path);
    comparer.Add(target2Path);
    comparer.Add(target3Path);
     
    comparer.Compare(File.Create(resultPath), new SaveOptions(), new CompareOptions());
    ```
