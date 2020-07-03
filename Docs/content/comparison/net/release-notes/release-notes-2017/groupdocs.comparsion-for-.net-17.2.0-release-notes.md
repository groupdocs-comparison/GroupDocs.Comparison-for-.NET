---
id: groupdocs-comparsion-for-net-17-2-0-release-notes
url: comparison/net/groupdocs-comparsion-for-net-17-2-0-release-notes
title: GroupDocs.Comparsion for .NET 17.2.0 Release Notes
weight: 10
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparsion for .NET 17.2.0{{< /alert >}}

## Major Features

There are 8 new features and 2 improvements and 5 fixes in this regular monthly release. The most notable are:

*   Add support of Imaging DjVu
*   Introduced support of support for Text Font in Watermark in Comparison.PDF
*   Introduced support of support for Images, Charts,  Smart Art, VBA Controls, Formulas in Comparison.Cells
*   Improved GroupDocs.Comparison.PDF comparison efficiency 

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-1123 | Integrate Metered licensing | New Feature |
| COMPARISONNET-1122 | GroupDocs.Comparison.PDF: Add support of comparing Text Font in Watermarks | New Feature |
| COMPARISONNET-1068 | GroupDocs.Comparison.Cells: Add support for Formulas | New Feature |
| COMPARISONNET-1065 | GroupDocs.Comparison.Cells: Add support for Images | New Feature |
| COMPARISONNET-1070 | GroupDocs.Comparison.Cells: Add support for Chart | New Feature |
| COMPARISONNET-1066 | GroupDocs.Comparison.Cells: Add support for Smart Art | New Feature |
| COMPARISONNET-1067 | GroupDocs.Comparison.Cells: Add support for VBA Controls | New Feature |
| COMPARISONNET-1108 | Add support of mobi format | New Feature |
| COMPARISONNET-1112 | Add support of Imaging DjVu | Improvement |
| COMPARISONNET-1080 | GroupDocs.Comparison.PDF: Improve comparison changes detection for Paragraphs | Improvement |
| COMPARISONNET-1129 | GroupDocs.Comparison.PDF: Fix bug when some lines are deleted or inserted where should not be | Bug |
| COMPARISONNET-1130 | GroupDocs.Comparison.PDF: Fix bug when first line of paragraph don't have indent but should have | Bug |
| COMPARISONNET-1131 | GroupDocs.Comparison.PDF: Fix bug when component change its page but dont change its position but should be | Bug |
| COMPARISONNET-1128 | GroupDocs.Comparison.PDF:Fix bug when first line of paragraph use as not paragraph line | Bug |
| COMPARISONNET-1132 | GroupDocs.Comparison.PDF: Fix bug when text from tables use twice with simple paragraphs | Bug |

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 17.2.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

### Metered Licensing 



```csharp
// Create new instance of GroupDocs.Comparison.Metered classs
GroupDocs.Comparison.Metered metered = new GroupDocs.Comparison.Metered();
 
// Set public and private key to metered instance
metered.SetMeteredKey("***", "***");
 
// Get metered value before usage of the comparison
decimal amountBefore = GroupDocs.Comparison.Metered.GetConsumptionQuantity();
 
Console.WriteLine("Amount consumed  before: " + amountBefore);
 
// compare files
string sourcePath = @"./data/source.docx";
string targetPath = @"./data/target.docx";
 
GroupDocs.Comparison comparison = new GroupDocs.Comparison();
Stream result = comparison.Compare(sourcePath, targetPath);
 
// Get metered value after usage of the comparison
decimal amountAfter = GroupDocs.Comparison.GetConsumptionQuantity();

Console.WriteLine("Amount consumed  after: " + amountAfter);
```
