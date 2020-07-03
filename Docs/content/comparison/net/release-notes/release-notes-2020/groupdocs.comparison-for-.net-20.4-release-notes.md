---
id: groupdocs-comparison-for-net-20-4-release-notes
url: comparison/net/groupdocs-comparison-for-net-20-4-release-notes
title: GroupDocs.Comparison for .NET 20.4 Release Notes
weight: 16
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 20.4{{< /alert >}}

## Major Features

Below the list of changes in release of GroupDocs.Comparison for .NET 20.4:

*   Added new function for show only inserted content
*   Improved function for showing target text for Presentations, Spreadsheet and Diagrams
*   Improved exception usage 
*   Fixed issues with library compatibility for Spreadsheed and Notes
*   Fixed number of exception while comparing Diagrams

|  Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2234 | Implement ShowInsertedContent Function | Feature |
| COMPARISONNET-2269 | Improve GetTargetText function for Diagrams | Improvement |
| COMPARISONNET-2242 | Improve GetTargetText function for Slides | Improvement |
| COMPARISONNET-2241 | Improve GetTargetText function for Cells | Improvement |
| COMPARISONNET-2271 | Improve exceptions usage | Improvement |
| COMPARISONNET-2272 | Unsupported Diagram Format Exception in Update tests | Bug |
| COMPARISONNET-2270 | Null Reference Exception in Diagrams | Bug |
| COMPARISONNET-2267 | Compatibility issue with Cells library when upgrade to version 20.3 | Bug |
| COMPARISONNET-2239 | Compatibility issue when updating Note library | Bug |

## Public API and Backward Incompatible Changes

## **Show inserted content**

Starting from version 20.4 **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** provides the ability to disable the display of added content in the result file.  
  
To use this feature you should specify in *CompareOptions ShowInsertedContent *propertyto false.  

```csharp
CompareOptions options = new CompareOptions();
options.ShowInsertedContent = false;

using (Comparer comparer = new Comparer(sourceDocumentPath))
{
     comparer.Add(targetDocumentPath);
     comparer.Compare(File.Create(outputPath), new SaveOptions(), options);
}
```
