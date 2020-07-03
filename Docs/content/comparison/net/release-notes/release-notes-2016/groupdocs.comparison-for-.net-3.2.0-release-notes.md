---
id: groupdocs-comparison-for-net-3-2-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-3-2-0-release-notes
title: GroupDocs.Comparison For .NET 3.2.0 Release Notes
weight: 7
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 3.2.0{{< /alert >}}

## Major Features

There are 14 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced support of saving comparison results as images
*   Introduced support of HTML format
*   Introduced improved Words comparison performance
*   Introduced improved Words comparison quality for tables
*   Introduced improved PDF comparison quality for tables and images
*   Introduced improved Cells general comparison quality
*   Introduced Apply/Discard changes support for Text format

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-787 | Save html files to word document when use Comparison.Text for comparison | New Feature |
| COMPARISONNET-769 | Add GetChanges and UpdateChanges methods for Comparison.Text | New Feature |
| COMPARISONNET-742 | Implement the Saving of result Comparison as images | New Feature |
| COMPARISONNET-730 | PDF: Implement the own absorber of tables | New Feature |
| COMPARISONNET-801 | Improve speed comparison Cells | Improvement |
| COMPARISONNET-750 | Comparison.Words significant performance improvements with new aligners | Improvement |
| COMPARISONNET-728 | Improve the displaying of images and text after process the comparison | Improvement |
| COMPARISONNET-726 | Implement function for correction of position and size Image after ImagePlacementAbsorber for Images from XForms | Improvement |
| COMPARISONNET-616 | Implement formulas comparison for Words format | Improvement |
| COMPARISONNET-533 | Implement of comparing pdf with the images | Improvement |
| COMPARISONNET-794 | GroupDocs.Comparison.Words: Aligning of paragraphs mismatch for the case when paragraphs is moved by page break | Bug |
| COMPARISONNET-780 | Out of memory exception in ComparisonText | Bug |
| COMPARISONNET-737 | Cannot open result file when graphics objects are used | Bug |
| COMPARISONNET-445 | Cells: original Excel tables layout is not supported. | Bug |

  
  

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 3.2.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}
