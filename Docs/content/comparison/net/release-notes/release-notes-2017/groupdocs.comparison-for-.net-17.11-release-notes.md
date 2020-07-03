---
id: groupdocs-comparison-for-net-17-11-release-notes
url: comparison/net/groupdocs-comparison-for-net-17-11-release-notes
title: GroupDocs.Comparison for .NET 17.11 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 17.11{{< /alert >}}

## Major Features

Below the list of the most notable features improvements and fixes for GroupDocs.Comparison 17.11:

*   Fixed a number of specific cases for Note format (words breaking, paragraph comparing)
*   Added intermediate paragraphs mechanism for simplifying comparing (for Words and Note)
*   Fixed styles comparing in Notes
*   PDF structure update
*   Fixes for working with images on PDF format

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Issue Type |
| --- | --- | --- |
| COMPARISONNET-1431 | Comparison.PDF: Refactor document builder using new content map | Improvement |
| COMPARISONNET-1429 | Comparison.PDF: Implement page content map | Improvement |
| COMPARISONNET-1427 | PDF Improving: Check and fix columns comparing | Improvement |
| COMPARISONNET-1424 | Improve Style changed deep for Comparison.Note | Improvement |
| COMPARISONNET-1422 | Add ParagraphMerger for Comparison.Note | Improvement |
| COMPARISONNET-1420 | Update pdf structure | Improvement |
| COMPARISONNET-1418 | Add IntermediateParagraphComparer to Words | Improvement |
| COMPARISONNET-1433 | Intermediate paragraphs problem in Word | Bug |
| COMPARISONNET-1432 | Comparison.Note: Fix special cases of word division | Bug |
| COMPARISONNET-1430 | Comparison.Note:Break line in the middle of a word | Bug |
| COMPARISONNET-1428 | Fix infinite loop in image rectangle PDF | Bug |
| COMPARISONNET-1423 | Comparison.Note Insert\\Delete empty paragraph before text | Bug |
| COMPARISONNET-1421 | Tables with similar coordinates overlap on each other | Bug |

# Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 17.11. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

None
