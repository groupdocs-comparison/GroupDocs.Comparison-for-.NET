---
id: groupdocs-comparison-for-net-20-3-release-notes
url: comparison/net/groupdocs-comparison-for-net-20-3-release-notes
title: GroupDocs.Comparison for .NET 20.3 Release Notes
weight: 18
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 20.3{{< /alert >}}

## Major Features

Below the list of changes in release of GroupDocs.Comparison for .NET 20.3:

*   Improved performance of multiple comparing of text documents
*   Fixed creating output HTML file while comparing source code files
*   Fixed exception when compare Diagrams documents
*   Fixed System.StackOverflownException when comparing PDF with images .NET

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-2214 | Increase performance for TXT MultiComparer | Improvement |
| COMPARISONNET-2235 | TextComparerResult does not create .html file for programming languages files | Bug |
| COMPARISONNET-2211 | System.StackOverflownException when comparing PDF with images .NET | Bug |
| COMPARISONNET-2209 | Comparing two vsdx files throws an exception | Bug |
| COMPARISONNET-2208 | Diagram text line break problem | Bug |

## Public API and Backward Incompatible Changes

**Getting Target text from Words documents**

Starting from version 20.3 **[GroupDocs.Comparison](https://products.groupdocs.com/comparison/net)** allows to getting target text of specific changes in Result document this working for **Word** documents.

To use this feature you should specify in *GetChanges TargetText* property

```csharp
using (Comparer comparer = new Comparer(sourceDocumentPath))
{
     comparer.Add(targetDocumentPath);
     comparer.Compare(outputPath);
     ChangeInfo[] changes = comparer.GetChanges();
     foreach (var change in changes)
     {
         var targetText = change.TargetText;
         Console.WriteLine(targetText);
     }
}
```
