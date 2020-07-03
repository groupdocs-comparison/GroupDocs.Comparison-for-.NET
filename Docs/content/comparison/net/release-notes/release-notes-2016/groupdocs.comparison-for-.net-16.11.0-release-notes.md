---
id: groupdocs-comparison-for-net-16-11-0-release-notes
url: comparison/net/groupdocs-comparison-for-net-16-11-0-release-notes
title: GroupDocs.Comparison For .NET 16.11.0 Release Notes
weight: 2
description: ""
keywords: 
productName: GroupDocs.Comparison for .NET
hideChildren: False
---
{{< alert style="info" >}}This page contains release notes for GroupDocs.Comparison for .NET 16.11.0{{< /alert >}}

## Major Features

There are 10 improvements and fixes in this regular monthly release. The most notable are:

*   Introduced support for new components in Comparison.Slides: objects with VBA scripts, style changes detection, detection of Picture Frames
*   Fixed issues with Comparison.Words with nested paragraphs
*   Fixed issues with Comparison.Cells with table structures
*   Improved ComparisonParagraphAbsorber for cases with tables

## Full List of Issues Covering all Changes in this Release

| Key | Summary | Category |
| --- | --- | --- |
| COMPARISONNET-1009 | GroupDocs.Comparison.Slides: Add support of comparing objects with VBA scripts | New Feature |
| COMPARISONNET-1013 | GroupDocs.Comparison.Slides: Add support of style changes detection | New Feature |
| COMPARISONNET-1026 | GroupDocs.Comparison.Slides: add support of detection of Picture Frames | New Feature |
| COMPARISONNET-1015 | GroupDocs.Comparison.Slides: Improve comparison performance | Improvement |
| COMPARISONNET-1012 | GroupDocs.Comparison.Slides: Extend engine to support all kind of images | Improvement |
| COMPARISONNET-957 | Cross-format engine: The case the comparison of tables with different results for all formats | Improvement |
| COMPARISONNET-970 | GroupDocs.Comparison.PDF:Add support for new components to new core | Improvement |
| COMPARISONNET-966 | GroupDocs.Comparison.Cells: If content of row is unique then row should be marked as Inserted or Deleted | Bug |
| COMPARISONNET-967 | GroupDocs.Comparison.Cells: The result table structure not conforming to primary table structure | Bug |
| COMPARISONNET-946 | GroupDocs.Comparison.Words: Exception: The newChild was created from a different document than the one that created this node. | Bug |

  

## Public API and Backward Incompatible Changes

{{< alert style="info" >}}This section lists public API changes that were introduced in GroupDocs.Comparison for .NET 16.11.0. It includes not only new and obsoleted public methods, but also a description of any changes in the behavior behind the scenes in GroupDocs.Comparison which may affect existing code. Any behavior introduced that could be seen as a regression and modifies existing behavior is especially important and is documented here.{{< /alert >}}

none
