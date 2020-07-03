---
id: groupdocs-comparison-for-net-18-7-release-notes
url: comparison/net/groupdocs-comparison-for-net-18-7-release-notes
title: GroupDocs.Comparison for .NET 18.7 Release Notes
weight: 6
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 18.7{{< /alert >}}

## Major Features

Below the list of most notable changes in  release of GroupDocs.Annotation for .NET 18.7:

*   Added comparison of group shapes for Diagrams
*   Implemented adding shape without Diagram’s Master
*   Improved Paragraph Comparer for Diagram’s
*   Improved StyleSheet Comparer for Html
*   Fixed issue with Style changes not highlighted in some specific cases of PDF documents comparison

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-1605 | Implement Group Shapes for Diagrams | New Feature |
| COMPARISONNET-1587 | Implement comparison different formats as image | New Feature |
| COMPARISONNET-1607 | Implement GluedShapes in Diagram | New Feature |
| COMPARISONNET-1608 | Improve StyleSheet Comparer for Html | Improvement |
| COMPARISONNET-1606 | Add shape without Diagram's Master | Improvement |
| COMPARISONNET-1619 | Output of PDF with images is not as expected | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 18.7. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

1.  Use "DiagramMasterSetting" to manage masters of the Comparison.Diagram.
    
    ```csharp
    MasterPath = string;// - User set custom master path
    UseSourceMaster = bool;// - true – use master from source and target together, false – use default or custom master
    ```
    
    Example:
    
    *   UseSourceMaster – false without MasterPath - use default master path
    *   UseSourceMaster – false with MasterPath - use custom master path
    *   UseSourceMaster – true - use master from source and target documents together
    
    Use "OriginalSize" to set document size when comparing image with different formats, this size will be used when document is converted to the picture.
    
    ```csharp
    OriginalSize.Width;// int
    OriginalSize.Heigth;// int;
    ```
